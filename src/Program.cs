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
            UpgradeUserSettings();
            var hueManager = new Manager();
            var profileManager = new ProfileManager();
            var mainForm = new MainForm(profileManager, hueManager);
            var msfsConnection = new Connector(mainForm.Handle, profileManager)
            {
                LightValueReceived = (light, value) =>
                {
                    try
                    {
                        byte brightness;
                        if (light.Bit > 0)
                        {
                            var mask = 1 << light.Bit;
                            var intValue = (Convert.ToInt64(value) & mask) >> light.Bit;
                            brightness = Convert.ToByte(intValue * light.Factor);
                        }
                        else
                        {
                            brightness = Convert.ToByte(value * light.Factor);
                        }
                        hueManager.SetLight(light, brightness);
                    }
                    catch(Exception) { }
                },
                SimConnectionStatusChanged = connected =>
                {
                    mainForm.OnSimConnectionStatusChanged(connected);
                }
            };
            mainForm.SimConnectMessage = () => msfsConnection.ReceiveMessage();
            hueManager.StartLocateBridges();
            Application.Run(mainForm);
        }

        private static void UpgradeUserSettings()
        {
            if (Settings.Default.UpgradeRequired)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;
                Settings.Default.Save();
            }
        }

    }
}