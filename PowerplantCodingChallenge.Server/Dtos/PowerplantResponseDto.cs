using Newtonsoft.Json;

namespace PowerplantCodingChallenge.Server.Dtos
{
    public class PowerplantResponseDto
    {
        public PowerplantResponseDto(string name, decimal power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name { get; set; }

        [JsonProperty(PropertyName = "p")]
        public decimal Power { get; set; }
    }
}
