using FluentAssertions;
using Moq;
using PowerplantCodingChallenge.Application;
using PowerplantCodingChallenge.Domain;
using PowerplantCodingChallenge.Server.Controllers;
using PowerplantCodingChallenge.Server.Dtos;

namespace PowerplantCodingChallenge.Server.Tests
{
    public class ProductionPlanControllerTests : BaseTests
    {
        private readonly Mock<IPowerplantService> powerplantServiceMock;
        private readonly ProductionPlanController productionPlanController;

        public ProductionPlanControllerTests()
        {
            this.powerplantServiceMock = new Mock<IPowerplantService>();

            this.productionPlanController = new ProductionPlanController(powerplantServiceMock.Object, this.mapper);
        }

        [Fact]
        public void ProductionPlan_PossibleScenario_ExpectedReturnCorrectCalculation()
        {
            // Arrange
            var expectedPowerplants = new List<PowerplantResponseDto>
            {
                new PowerplantResponseDto("windpark1", 90),
                new PowerplantResponseDto("windpark2", 21.6m),
                new PowerplantResponseDto("gasfiredbig1", 460),
                new PowerplantResponseDto("gasfiredbig2", 338.4m),
                new PowerplantResponseDto("gasfiredsomewhatsmaller", 0),
                new PowerplantResponseDto("tj1", 0),
            };

            this.powerplantServiceMock.Setup(powerplantService => powerplantService.CalculateMeritOrder(It.IsAny<ProductionPlan>()))
                .Returns(new Dictionary<string, decimal>()
                {
                    { "windpark1", 90 },
                    { "windpark2", 21.6m },
                    { "gasfiredbig1", 460 },
                    { "gasfiredbig2", 338.4m },
                    { "gasfiredsomewhatsmaller", 0 },
                    { "tj1", 0 }
                });

            var productionPlanDto = new ProductionPlanDto
            {
                Load = 910,
                Fuels = new FuelCostDto
                {
                    GasCost = 13.4,
                    KersosineCost = 50.8,
                    Co2 = 20,
                    WindEfficiency = 60
                },
                Powerplants = new List<PowerplantDto> {
                    new PowerplantDto
                    {
                        Name = "gasfiredbig1",
                        Type = PowerplantType.gasfired,
                        Efficiency = 0.53m,
                        PMin = 100,
                        PMax = 460
                    },
                    new PowerplantDto
                    {
                        Name = "gasfiredbig2",
                        Type = PowerplantType.gasfired,
                        Efficiency = 0.53m,
                        PMin = 100,
                        PMax = 460
                    },
                    new PowerplantDto
                    {
                        Name = "gasfiredsomewhatsmaller",
                        Type = PowerplantType.gasfired,
                        Efficiency = 0.37m,
                        PMin = 40,
                        PMax = 210
                    },
                    new PowerplantDto
                    {
                        Name = "tj1",
                        Type = PowerplantType.turbojet,
                        Efficiency = 0.3m,
                        PMin = 0,
                        PMax = 16
                    },
                    new PowerplantDto
                    {
                        Name = "windpark1",
                        Type = PowerplantType.windturbine,
                        Efficiency = 1,
                        PMin = 0,
                        PMax = 150
                    },
                    new PowerplantDto
                    {
                        Name = "windpark2",
                        Type = PowerplantType.windturbine,
                        Efficiency = 1,
                        PMin = 0,
                        PMax = 36
                    }
                }
            };

            // Act
            var result = this.productionPlanController.ProductionPlan(productionPlanDto);

            // Assert
            result.Should().BeEquivalentTo(expectedPowerplants);
        }
    }
}