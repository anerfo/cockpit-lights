
using System.Text.Json.Serialization;

namespace CockpitLights.Model
{
    public class Light
    {
        public string? BridgeId;
        public string? LightName;
        public string? Simvar;
        public int Color = 0xFFFFFF;
        public double Factor = 1.0;
        public bool IsSameLight(Light other)
        {
            return other.BridgeId == BridgeId && other.LightName == LightName;
        }

        [JsonIgnore()]
        public string FullName => BridgeId + LightName;
    }
}
