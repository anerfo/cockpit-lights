using CockpitLights.Model;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace CockpitLights
{
    internal class ProfileManager
    {
        public ICollection<Profile> Profiles { get; private set; }
        private string ActiveProfileName { get; set; } = "Default";

        public ProfileManager()
        {
            Profiles = LoadProfiles();
            ActiveProfileName = string.IsNullOrEmpty(Settings.Default.ActiveProfile) ? ActiveProfileName : Settings.Default.ActiveProfile;
        }

        public ICollection<Profile> LoadProfiles()
        {
            var result = new List<Profile>();
            if (Settings.Default.Profiles != null)
            {
                foreach (var profile in Settings.Default.Profiles)
                {
                    var deserialized = JsonConvert.DeserializeObject<Profile>(profile!);
                    result.Add(deserialized!);
                }
            }
            else
            {
                result.Add(new Profile { Name = ActiveProfileName });
            }

            return result;
        }

        public void SaveProfiles()
        {
            if (Settings.Default.Profiles == null)
            {
                Settings.Default.Profiles = new StringCollection();
            }
            Settings.Default.Profiles.Clear();
            foreach (var profile in Profiles)
            {
                Settings.Default.Profiles.Add(JsonConvert.SerializeObject(profile));
            }
            Settings.Default.Save();
        }

        public Profile ActiveProfile => Profiles.FirstOrDefault(p => p.Name == ActiveProfileName)! ?? Profiles.FirstOrDefault()!;

        internal void Store(Light light)
        {
            ActiveProfile.Store(light);
            SaveProfiles();
        }

        internal void NewProfile(string name)
        {
            Profiles.Add(new Profile() { Name = name });
            SaveProfiles();
        }

        internal void SetActiveProfile(string selectedItem)
        {
            ActiveProfileName = selectedItem;
            Settings.Default.ActiveProfile = ActiveProfileName;
            Settings.Default.Save();
        }

        internal void DeleteActiveProfile()
        {
            Profiles.Remove(ActiveProfile);
            Settings.Default.ActiveProfile = ActiveProfileName;
            Settings.Default.Save();
            SaveProfiles();
        }
    }
}
