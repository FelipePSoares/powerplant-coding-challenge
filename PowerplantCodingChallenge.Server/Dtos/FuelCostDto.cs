using System.Text.Json.Serialization;

namespace PowerplantCodingChallenge.Server.Dtos
{
    public class FuelCostDto
    {
        [JsonPropertyName(@"gas(euro/MWh)")]
        public double GasCost { get; set; }

        [JsonPropertyName(@"kerosine(euro/MWh)")]
        public double KersosineCost { get; set; }

        [JsonPropertyName(@"co2(euro/ton)")]
        public double Co2 { get; set; }

        [JsonPropertyName(@"wind(%)")]
        public int WindEfficiency { get; set; }
    }
}
