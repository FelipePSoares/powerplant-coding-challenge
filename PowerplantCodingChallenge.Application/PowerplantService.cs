using System.Collections.Generic;
using System.Linq;
using PowerplantCodingChallenge.Domain;

namespace PowerplantCodingChallenge.Application
{
    public class PowerplantService : IPowerplantService
    {
        public Dictionary<string, decimal> CalculateMeritOrder(ProductionPlan productionPlan)
        {
            productionPlan.UpdateCostPerMwhAndPMaxAvailablePerPowerplant();

            productionPlan.CalculateAndSetTheBestLoadDistribution();

            return productionPlan.Powerplants
                .OrderBy(powerplant => powerplant.CostPerMWh)
                .ToDictionary(powerplant => powerplant.Name, powerplant => powerplant.P);
        }
    }
}
