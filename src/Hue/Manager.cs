using Q42.HueApi.Interfaces;
using Q42.HueApi;
using Q42.HueApi.ColorConverters;
using Q42.HueApi.ColorConverters.Original;
using Q42.HueApi.Models.Bridge;

namespace CockpitLights.Hue
{
    internal class Manager
    {
        private readonly CancellationToken LocateCancellationToken = new();
        private readonly ApiKeyManager ApiKeyManager = new();

        public Action<IEnumerable<LocatedBridge>> BridgesDetected = bridges => { };
        public Dictionary<string, byte> LastSend = new();
        private Dictionary<string, string> IpAddresses = new();

        public Manager()
        {
            StartLocateBridges();
        }

        public void StartLocateBridges()
        {
            IBridgeLocator locator = new HttpBridgeLocator();
            locator.LocateBridgesAsync(LocateCancellationToken).ContinueWith(bridgesLocateTask =>
            {
                if (bridgesLocateTask.IsFaulted == false)
                {
                    IpAddresses.Clear();
                    foreach (var bridge in bridgesLocateTask.Result)
                    {
                        IpAddresses[bridge.BridgeId] = bridge.IpAddress;
                    }
                    BridgesDetected(bridgesLocateTask.Result);
                }
            });
        }

        public async Task<IEnumerable<Light>> StartGetLights(string id)
        {
            if (IpAddresses.TryGetValue(id, out var ipAddress))
            {
                var client = new LocalHueClient(ipAddress);
                client.Initialize(ApiKeyManager.GetApiKey(id));
                var lights = await client.GetLightsAsync();
                return lights;
            }
            return new List<Light>();
        }

        public async Task StartRegister(string id)
        {
            if (IpAddresses.TryGetValue(id, out var ipAddress))
            {
                ILocalHueClient client = new LocalHueClient(ipAddress);
                var apiKey = await client.RegisterAsync(Application.ProductName, Environment.MachineName);
                ApiKeyManager.AddApiKey(ipAddress, apiKey!);
            }
        }

        public async void SetLight(Model.Light light, byte brightness)
        {
            if (light == null) return;
            if (string.IsNullOrEmpty(light.BridgeId)) return;
            if (IpAddresses.TryGetValue(light.BridgeId, out var ipAddress) == false) return;
            if (string.IsNullOrEmpty(light.LightName)) return;
            if (LastSend.ContainsKey(light.FullName) && LastSend[light.FullName] == brightness) return;
            LastSend[light.FullName] = brightness;

            var client = new LocalHueClient(ipAddress);
            client.Initialize(ApiKeyManager.GetApiKey(ipAddress));
            var command = new LightCommand();
            if (brightness > 0)
            {
                var color = new RGBColor
                {
                    R = (light.Color & 0xFF0000) >> 16,
                    G = (light.Color & 0xFF00) >> 8,
                    B = light.Color & 0xFF
                };
                command.TurnOn().SetColor(color);
                command.Brightness = brightness;
            }
            else
            {
                command.TurnOff();
            }
            var lights = await client.GetLightsAsync();
            var foundLight = lights.FirstOrDefault(l => l.Name == light.LightName);
            if (foundLight != null)
            {
                await client.SendCommandAsync(command, new List<string> { foundLight.Id });
            }
        }
    }
}
