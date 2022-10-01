namespace CockpitLights.Hue
{
    internal class ApiKeyManager
    {
        private const char Separator = ';';
        private Dictionary<string, string> GetApiKeys()
        {
            var keys = Settings.Default.ApiKeys;
            var result = new Dictionary<string, string>();
            if (keys != null)
            {
                foreach (var key in keys)
                {
                    var entry = key!.Split(Separator);
                    result[entry[0]] = entry[1];
                }
            }
            return result;
        }

        public string GetApiKey(string id)
        {
            var keys = GetApiKeys();
            return keys.ContainsKey(id) ? keys[id] : String.Empty;
        }

        public void AddApiKey(string id, string apiKey)
        {
            if(string.IsNullOrEmpty(GetApiKey(id)))
            {
                if(Settings.Default.ApiKeys == null)
                {
                    Settings.Default.ApiKeys = new System.Collections.Specialized.StringCollection();
                }
                Settings.Default.ApiKeys.Add($"{id}{Separator}{apiKey}");
                Settings.Default.Save();
            }
        }
    }
}
