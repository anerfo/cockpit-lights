using System.Collections.ObjectModel;

namespace CockpitLights.Model
{
    internal class Profile
    {
        public Collection<Light> Lights { get; private set; } = new();

        public Light GetLight(string ipAddress, string name)
        {
            var entry = new Light { BridgeId = ipAddress, LightName = name };
            if (Contains(entry) == false)
            {
                return entry;
            }
            return Lights.First(entry => entry.IsSameLight(entry));
        }

        public void Store(Light entry)
        {
            if (Contains(entry))
            {
                Update(entry);
            }
            else
            {
                Lights.Add(entry);
            }
        }

        private void Update(Light entry)
        {
            foreach (var current in Lights)
            {
                if (current.IsSameLight(entry))
                {
                    Lights.Add(entry);
                }
                else
                {
                    Lights.Add(current);
                }
            }
        }

        private bool Contains(Light entry)
        {
            return Lights.Any(current => entry.IsSameLight(current));
        }
    }
}
