using CockpitLights.Model;
using Microsoft.FlightSimulator.SimConnect;
using Timer = System.Timers.Timer;

namespace CockpitLights.Msfs
{
    internal class Connector
    {
        private Timer ConnectTimer;
        private Timer RequestTimer;
        private SimConnect? SimConnect;
        private IntPtr Handle;
        public IEnumerable<Light> Lights;

        public Action<Light, byte> LightValueReceived = (entry, value) => { };
        private Dictionary<REQUEST, Light> RunningRequests;
        private Dictionary<string, REQUEST> DefineIds;

        public Connector(IntPtr handle, IEnumerable<Light> lights)
        {
            Handle = handle;
            Lights = lights;
            SimConnect = null;
            ConnectTimer = new Timer(Constants.ConnectInterval);
            ConnectTimer.Start();
            ConnectTimer.Elapsed += ConnectTimerElapsed;
            RequestTimer = new Timer(Constants.RequestInterval);
            RequestTimer.Elapsed += RequestTimerElapsed;
            RunningRequests = new();
            DefineIds = new();
        }

        public void ReceiveMessage()
        {
            SimConnect?.ReceiveMessage();
        }

        private void ConnectTimerElapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            if (SimConnect == null)
            {
                try
                {
                    SimConnect = new SimConnect(Application.ProductName, Handle, Constants.WM_USER_SIMCONNECT, null, 0);
                    ConnectTimer.Stop();
                    SimConnect.OnRecvOpen += new SimConnect.RecvOpenEventHandler(SimConnect_OnRecvOpen);
                    SimConnect.OnRecvQuit += new SimConnect.RecvQuitEventHandler(SimConnect_OnRecvQuit);
                    SimConnect.OnRecvException += new SimConnect.RecvExceptionEventHandler(SimConnect_OnRecvException);
                    SimConnect.OnRecvSimobjectDataBytype += new SimConnect.RecvSimobjectDataBytypeEventHandler(SimConnect_OnRecvSimobjectDataBytype);
                }
                catch (Exception)
                {

                }
            }
        }

        private void SimConnect_OnRecvSimobjectDataBytype(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA_BYTYPE data)
        {
            var id = (REQUEST)data.dwDefineID;
            if (RunningRequests.ContainsKey(id))
            {
                var entry = RunningRequests[id];
                RunningRequests.Remove(id);
                var value = (double)data.dwData[0];
                var brightness = (byte)(value * entry.Factor);
                LightValueReceived(entry, brightness);
            }
        }

        private void SimConnect_OnRecvException(SimConnect sender, SIMCONNECT_RECV_EXCEPTION data)
        {

        }

        private void SimConnect_OnRecvQuit(SimConnect sender, SIMCONNECT_RECV data)
        {
            SimConnect = null;
            ConnectTimer.Start();
            RequestTimer.Stop();
        }

        private void SimConnect_OnRecvOpen(SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            RegisterSimVars();
            RequestTimer.Start();
        }

        private void RequestTimerElapsed(object? sender, EventArgs e)
        {
            if (SimConnect != null)
            {
                foreach (var light in Lights)
                {
                    var id = DefineIds[light.Simvar!];
                    if (RunningRequests.ContainsKey(id) == false)
                    {
                        RunningRequests[id] = light;
                        SimConnect.RequestDataOnSimObjectType(Constants.RudderPedalRequest.eRequest, id, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
                    }
                }
            }
        }

        private void RegisterSimVars()
        {
            if (SimConnect != null)
            {
                foreach (var light in Lights)
                {
                    if (DefineIds.ContainsKey(light.Simvar!) == false)
                    {
                        var id = (REQUEST)DefineIds.Count;
                        DefineIds[light.Simvar!] = id;
                        SimConnect.AddToDataDefinition(id, light.Simvar, string.Empty, SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
                        SimConnect.RegisterDataDefineStruct<double>(id);
                    }
                }
            }
        }
    }
}
