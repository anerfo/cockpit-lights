using CockpitLights.Hue;
using CockpitLights.Model;
using CockpitLights.Msfs;
using Q42.HueApi.Models.Bridge;

namespace CockpitLights
{
    public partial class MainForm : Form
    {
        private Manager HueManager;
        private Connector MsfsConnection;
        private Profile CurrentProfile;
        private const string NoBridgeFoundMessage = "No Hue Bridge found";

        public MainForm()
        {
            InitializeComponent();
            CurrentProfile = new Profile();
            HueManager = new Manager()
            {
                BridgesDetected = bridges => BeginInvoke(OnBridesDetected, bridges)
            };
            MsfsConnection = new Connector(Handle, CurrentProfile.Lights)
            {
                LightValueReceived = (light, value) => {
                    HueManager.SetLight(light, value);
                }
            };
        }

        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_USER_SIMCONNECT)
            {
                MsfsConnection.ReceiveMessage();
            }
            else
            {
                base.DefWndProc(ref m);
            }
        }

        private void OnBridesDetected(IEnumerable<LocatedBridge> bridges)
        {
            BridgesView.Items.Clear();
            if (bridges.Any())
            {
                foreach (var bridge in bridges)
                {
                    BridgesView.Items.Add(bridge.BridgeId);
                }
            }
            else
            {
                BridgesView.Items.Add(NoBridgeFoundMessage);
            }
        }

        private async void BridgesView_SelectedIndexChanged(object sender, EventArgs e)
        {
            RegisterButton.Visible = false;
            LightsView.Items.Clear();
            LightsView.Items.Add("Fetching...");
            var lights = await HueManager.StartGetLights((string)BridgesView.SelectedItem);
            LightsView.Items.Clear();
            if(lights.Any())
            {
                foreach (var light in lights)
                {
                    LightsView.Items.Add(light.Name);
                }
            }
            else
            {
                RegisterButton.Visible = true;
            }
        }

        private async void RegisterButtonClick(object sender, EventArgs e)
        {
            try
            {
                await HueManager.StartRegister((string)BridgesView.SelectedItem);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Registration failed");
            }
            BridgesView_SelectedIndexChanged(sender, e);

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            CurrentProfile.Store(GetCurrentMapEntry());
        }

        private Light GetCurrentMapEntry()
        {
            double.TryParse(FactorView.Text, out double factor);
            return new Light
            {
                BridgeId = (string)BridgesView.SelectedItem,
                LightName = (string)LightsView.SelectedItem,
                Color = ColorView.BackColor.ToArgb(),
                Factor = factor,
                Simvar = SimVarView.Text
            };
        }

        private void LightsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var entry = CurrentProfile.GetLight((string)BridgesView.SelectedItem, (string)LightsView.SelectedItem);
            if (entry != null)
            {
                SimVarView.Text = entry.Simvar;
                FactorView.Text = $"{entry.Factor}";
                ColorView.BackColor = Color.FromArgb(entry.Color);
            }
        }

        private void ColorView_Click(object sender, EventArgs e)
        {
            ColorPicker.Color = ColorView.BackColor;
            ColorPicker.ShowDialog();
            ColorView.BackColor = ColorPicker.Color;
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            HueManager.SetLight(GetCurrentMapEntry(), 255);
        }
    }
}