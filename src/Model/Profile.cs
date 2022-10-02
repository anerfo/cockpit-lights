using System.Collections.ObjectModel;

namespace CockpitLights.Model
{
    internal class Profile
    {
        public Collection<Light> Lights { get; private set; } = new();
        public string Name { get; set; } = "New Profile";

        public Light GetLight(string ipAddress, string name)
        {
            var light = new Light { BridgeId = ipAddress, LightName = name };
            if (Contains(light) == false)
            {
                return light;
            }
            return Lights.First(entry => entry.IsSameLight(entry));
        }

        public void Store(Light entry)
        {
            Lights.Where(l => l.IsSameLight(entry)).ToList().ForEach(l => Lights.Remove(l));
            Lights.Add(entry);
        }

        private bool Contains(Light light)
        {
            return Lights.Any(current => light.IsSameLight(current));
        }
    }
}
