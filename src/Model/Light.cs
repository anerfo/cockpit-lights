using System.Xml.Serialization;

namespace CockpitLights.Model
{
    public class Light
    {
        public string? BridgeId;
        public string? LightName;
        public string? Simvar;
        public int Color;
        public double Factor;

        public static Light? Deserialize(string toDeserialize)
        {
            var xmlSerializer = new XmlSerializer(typeof(Light));

            using (var textReader = new StringReader(toDeserialize))
            {
                return xmlSerializer.Deserialize(textReader) as Light;
            }
        }

        public string Serialize()
        {
            var xmlSerializer = new XmlSerializer(GetType());

            using (var textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, this);
                return textWriter.ToString();
            }
        }

        public bool IsSameLight(Light other)
        {
            return other.BridgeId == BridgeId && other.LightName == LightName;
        }

        public string FullName => BridgeId + LightName;
    }
}
