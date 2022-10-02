using CockpitLights.Hue;
using CockpitLights.Msfs;

namespace CockpitLights
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var hueManager = new Manager();
            var profileManager = new ProfileManager();
            var mainForm = new MainForm(profileManager, hueManager);
            var msfsConnection = new Connector(mainForm.Handle, profileManager)
            {
                LightValueReceived = (light, value) =>
                {
                    hueManager.SetLight(light, value);
                }
            };
            mainForm.SimConnectMessage = () => msfsConnection.ReceiveMessage();
            hueManager.StartLocateBridges();
            Application.Run(mainForm);
        }
    }
}