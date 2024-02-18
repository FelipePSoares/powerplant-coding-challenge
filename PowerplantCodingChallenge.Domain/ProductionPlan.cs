using System;
using System.Collections.Generic;
using System.Linq;
using PowerplantCodingChallenge.Infrastructure.Exceptions;

namespace PowerplantCodingChallenge.Domain
{
    public class ProductionPlan
    {
        public decimal Load { get; set; }
        public FuelCost Fuels { get; set; } = new FuelCost();
        public List<Powerplant> Powerplants { get; set; } = new List<Powerplant>();

        public void UpdateCostPerMwhAndPMaxAvailablePerPowerplant()
        {
            Powerplants.ForEach(p => p.UpdateCostPerMwhAndPMaxAvailable(this.Fuels));
        }

        public void CalculateAndSetTheBestLoadDistribution()
        {
            foreach (var powerplant in Powerplants.OrderBy(powerplant => powerplant.CostPerMWh))
            {
                var power = Math.Max(Math.Min(powerplant.PMaxAvailable, this.Load), powerplant.PMin);

                powerplant.SetP(power);
                this.Load -= power;

                if (this.Load <= 0)
                    break;
            }

            if (this.Load < 0)
            {
                this.Load *= -1;
                foreach (var powerplant in Powerplants.Where(p => p.P != 0).OrderByDescending(powerplant => powerplant.CostPerMWh))
                {
                    var availableToRemove = powerplant.P - powerplant.PMin;

                    var powerToRemove = Math.Min(availableToRemove, this.Load);
                    powerplant.SetP(powerplant.P - powerToRemove);
                    this.Load -= powerToRemove;

                    if (this.Load == 0)
                        break;
                }
            }

            if (this.Load != 0)
                throw new ValidationException(nameof(this.Load), "It's impossible generate the necessary power with the power plants availables");
        }
    }
}
