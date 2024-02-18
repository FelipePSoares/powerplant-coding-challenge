using FluentAssertions;

namespace PowerplantCodingChallenge.Domain.Tests
{
    public class ProductionPlanTests
    {
        [Fact]
        public void CalculateAndSetTheBestLoadDistribution_FirstSuccessExample_ExpectedTheRightDistribution()
        {
            // Arrange
            var expectedPowerplants = new Dictionary<string, decimal> 
            {
                { "windpark1", 90 },
                { "windpark2", 21.6m },
                { "gasfiredbig1", 460 },
                { "gasfiredbig2", 338.4m },
                { "gasfiredsomewhatsmaller", 0 },
                { "tj1", 0 },
            };

            var productionPlan = new ProductionPlan()
            {
                Load = 910,
                Fuels = new FuelCost
                {
                    GasCost = 13.4m,
                    KersosineCost = 50.8m,
                    Co2 = 20,
                    WindEfficiency = 60
                },
                Powerplants = new List<Powerplant> {
                    new Powerplant
                    {
                        Name = "gasfiredbig1",
                        Type = PowerplantType.gasfired,
                        Efficiency = 0.53m,
                        PMin = 100,
                        PMax = 460
                    },
                    new Powerplant
                    {
                        Name = "gasfiredbig2",
                        Type = PowerplantType.gasfired,
                        Efficiency = 0.53m,
                        PMin = 100,
                        PMax = 460
                    },
                    new Powerplant
                    {
                        Name = "gasfiredsomewhatsmaller",
                        Type = PowerplantType.gasfired,
                        Efficiency = 0.37m,
                        PMin = 40,
                        PMax = 210
                    },
                    new Powerplant
                    {
                        Name = "tj1",
                        Type = PowerplantType.turbojet,
                        Efficiency = 0.3m,
                        PMin = 0,
                        PMax = 16
                    },
                    new Powerplant
                    {
                        Name = "windpark1",
                        Type = PowerplantType.windturbine,
                        Efficiency = 1,
                        PMin = 0,
                        PMax = 150
                    },
                    new Powerplant
                    {
                        Name = "windpark2",
                        Type = PowerplantType.windturbine,
                        Efficiency = 1,
                        PMin = 0,
                        PMax = 36
                    }
                }
            };

            productionPlan.UpdateCostPerMwhAndPMaxAvailablePerPowerplant();

            // Act
            productionPlan.CalculateAndSetTheBestLoadDistribution();

            // Assert
            productionPlan.Powerplants.ToDictionary(powerplant => powerplant.Name, powerplant => powerplant.P)
                .Should().BeEquivalentTo(expectedPowerplants);
        }

        [Fact]
        public void CalculateAndSetTheBestLoadDistribution_SecondSuccessExamples_ExpectedTheRightDistribution()
        {
            // Arrange
            var expectedPowerplants = new Dictionary<string, decimal>
            {
                { "windpark1", 0 },
                { "windpark2", 0 },
                { "gasfiredbig1", 380 },
                { "gasfiredbig2", 100 },
                { "gasfiredsomewhatsmaller", 0 },
                { "tj1", 0 },
            };

            var productionPlan = new ProductionPlan()
            {
                Load = 480,
                Fuels = new FuelCost
                {
                    GasCost = 13.4m,
                    KersosineCost = 50.8m,
                    Co2 = 20,
                    WindEfficiency = 0
                },
                Powerplants = new List<Powerplant> {
                    new Powerplant
                    {
                        Name = "gasfiredbig1",
                        Type = PowerplantType.gasfired,
                        Efficiency = 0.53m,
                        PMin = 100,
                        PMax = 460
                    },
                    new Powerplant
                    {
                        Name = "gasfiredbig2",
                        Type = PowerplantType.gasfired,
                        Efficiency = 0.53m,
                        PMin = 100,
                        PMax = 460
                    },
                    new Powerplant
                    {
                        Name = "gasfiredsomewhatsmaller",
                        Type = PowerplantType.gasfired,
                        Efficiency = 0.37m,
                        PMin = 40,
                        PMax = 210
                    },
                    new Powerplant
                    {
                        Name = "tj1",
                        Type = PowerplantType.turbojet,
                        Efficiency = 0.3m,
                        PMin = 0,
                        PMax = 16
                    },
                    new Powerplant
                    {
                        Name = "windpark1",
                        Type = PowerplantType.windturbine,
                        Efficiency = 1,
                        PMin = 0,
                        PMax = 150
                    },
                    new Powerplant
                    {
                        Name = "windpark2",
                        Type = PowerplantType.windturbine,
                        Efficiency = 1,
                        PMin = 0,
                        PMax = 36
                    }
                }
            };

            productionPlan.UpdateCostPerMwhAndPMaxAvailablePerPowerplant();

            // Act
            productionPlan.CalculateAndSetTheBestLoadDistribution();

            // Assert
            productionPlan.Powerplants.ToDictionary(powerplant => powerplant.Name, powerplant => powerplant.P)
                .Should().BeEquivalentTo(expectedPowerplants);
        }
    }
}
