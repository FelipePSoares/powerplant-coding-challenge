using PowerplantCodingChallenge.Domain;
using System.Collections.Generic;

namespace PowerplantCodingChallenge.Application
{
    public interface IPowerplantService
    {
        Dictionary<string, decimal> CalculateMeritOrder(ProductionPlan productionPlan);
    }
}
