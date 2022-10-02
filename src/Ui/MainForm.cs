using CockpitLights.Hue;
using CockpitLights.Model;
using CockpitLights.Msfs;
using Q42.HueApi.Models.Bridge;
using System.Xml.Linq;

namespace CockpitLights
{
    public partial class MainForm : Form
    {
        private Manager HueManager;
        private ProfileManager ProfileManager;
        private const string NoBridgeFoundMessage = "No Hue Bridge found";
        public Action SimConnectMessage = () => { };

        internal MainForm(ProfileManager profileManager, Manager hueManager)
        {
            InitializeComponent();
            ProfileManager = profileManager;
            HueManager = hueManager;
            hueManager.BridgesDetected = bridges => BeginInvoke(OnBridesDetected, bridges);
            UpdateProfiles();
        }

        private void UpdateProfiles()
        {
            var updateRequired = ProfileView.Items.Count != ProfileManager.Profiles.Count;
            foreach (var profile in ProfileManager.Profiles)
            {
                if(ProfileView.Items.Contains(profile.Name) == false)
                {
                    updateRequired = true;
                    break;
                }
            }
            if (updateRequired)
            {
                ProfileView.Items.Clear();
                foreach (var profile in ProfileManager.Profiles)
                {
                    ProfileView.Items.Add(profile.Name);
                }
                ProfileView.SelectedItem = ProfileManager.ActiveProfile?.Name;
            }
        }

        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_USER_SIMCONNECT)
            {
                SimConnectMessage();
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
            ProfileManager.Store(GetCurrentMapEntry());
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
            var light = ProfileManager.ActiveProfile.GetLight((string)BridgesView.SelectedItem, (string)LightsView.SelectedItem);
            if (light != null)
            {
                SimVarView.Text = light.Simvar;
                FactorView.Text = $"{light.Factor}";
                ColorView.BackColor = Color.FromArgb(light.Color);
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
            HueManager.SetLight(GetCurrentMapEntry(), 255, true);
        }

        private void AddProfileButton_Click(object sender, EventArgs e)
        {
            if (ProfileNameView.Visible)
            {
                AddNewProfile(ProfileNameView.Text);
                ProfileNameView.Hide();
            }
            else
            {
                ProfileNameView.Show();
                ProfileNameView.Focus();
            }
        }

        private void ProfileView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProfileManager.SetActiveProfile((string)ProfileView.SelectedItem);
            LightsView_SelectedIndexChanged(sender, e);
        }

        private void AddNewProfile(string name)
        {
            ProfileManager.NewProfile(name);
            UpdateProfiles();
        }

        private void ProfileNameView_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                AddNewProfile(ProfileNameView.Text);
                ProfileNameView.Hide();
            }
        }

        private void RemoveProfileButton_Click(object sender, EventArgs e)
        {
            ProfileManager.DeleteActiveProfile();
            UpdateProfiles();
        }

        internal void OnSimConnectionStatusChanged(bool connected)
        {
            SimConnectionStatusView.Text = connected ? "✔ Connected" : "❌ Not connected";
        }
    }
}