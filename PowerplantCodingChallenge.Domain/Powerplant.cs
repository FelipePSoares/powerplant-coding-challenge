using PowerplantCodingChallenge.Infrastructure.Exceptions;

namespace PowerplantCodingChallenge.Domain
{
    public class Powerplant
    {
        private const decimal CO2EmittedByMwh = 0.3m;

        public string Name { get; set; } = "default";
        public PowerplantType Type { get; set; }
        public decimal Efficiency { get; set; }
        public decimal PMin { get; set; }
        public decimal PMax { get; set; }

        public decimal CostPerMWh { get; private set; }
        public decimal PMaxAvailable { get; private set; }
        public decimal P { get; private set; }

        public void UpdateCostPerMwhAndPMaxAvailable(FuelCost fuelCost)
        {
            switch (this.Type) {
                case PowerplantType.gasfired:
                    this.CostPerMWh = (fuelCost.GasCost / this.Efficiency) + (fuelCost.Co2 / CO2EmittedByMwh);
                    this.PMaxAvailable = this.PMax;
                    break;
                case PowerplantType.turbojet:
                    this.CostPerMWh = fuelCost.KersosineCost / this.Efficiency;
                    this.PMaxAvailable = this.PMax;
                    break;
                case PowerplantType.windturbine:
                    this.CostPerMWh = 0;
                    this.PMaxAvailable = (PMax * fuelCost.WindEfficiency) / 100;
                    break;
                default:
                    break;
            }
        }

        public void SetP(decimal p) 
        {
            if (p > PMax || p < PMin)
                throw new ValidationException(nameof(p), $"Can't produce this potency({p}) in this powerplant!");

            this.P = p;
        }
    }
}
