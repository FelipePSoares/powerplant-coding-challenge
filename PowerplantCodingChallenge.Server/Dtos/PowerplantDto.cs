using System.Text.Json.Serialization;
using PowerplantCodingChallenge.Domain;

namespace PowerplantCodingChallenge.Server.Dtos
{
    public class PowerplantDto
    {
        public string Name { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PowerplantType Type { get; set; }
        public decimal Efficiency { get; set; }
        public decimal PMin { get; set; }
        public decimal PMax { get; set; }
    }
}
