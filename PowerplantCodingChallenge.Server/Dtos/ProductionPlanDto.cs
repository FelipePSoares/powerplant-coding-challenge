namespace PowerplantCodingChallenge.Server.Dtos
{
    public class ProductionPlanDto
    {
        public double Load { get; set; }
        public FuelCostDto Fuels { get; set; } = new FuelCostDto();
        public List<PowerplantDto> Powerplants { get; set; } = new List<PowerplantDto>();
    }
}
