using FluentAssertions;
using PowerplantCodingChallenge.Infrastructure.Exceptions;

namespace PowerplantCodingChallenge.Domain.Tests
{
    public class PowerplantTests
    {
        [Fact]
        public void SetCostPerMwh_WindTurbinePowerplant_ExpectedCostPerMWhEqualZero()
        {
            // Arrange
            var windTurbinePowerplant = new Powerplant()
            {
                Type = PowerplantType.windturbine,
                PMax = 150
            };

            var fuelCost = new FuelCost()
            {
                WindEfficiency = 60
            };

            // Act
            windTurbinePowerplant.UpdateCostPerMwhAndPMaxAvailable(fuelCost);

            // Assert
            windTurbinePowerplant.CostPerMWh.Should().Be(0);
            windTurbinePowerplant.PMaxAvailable.Should().Be(90);
        }

        [Fact]
        public void SetCostPerMwh_TurboJetPowerplant_ExpectedCostPerMWh()
        {
            // Arrange
            var turboJetPowerplant = new Powerplant()
            {
                Type = PowerplantType.turbojet,
                Efficiency = 0.3m
            };

            var fuelCost = new FuelCost()
            {
                KersosineCost = 50.8m
            };

            // Act
            turboJetPowerplant.UpdateCostPerMwhAndPMaxAvailable(fuelCost);

            // Assert
            turboJetPowerplant.CostPerMWh.Should().Be(169.33333333333333333333333333M);
        }

        [Fact]
        public void SetCostPerMwh_GasFiredPowerplant_ExpectedCostPerMWh()
        {
            // Arrange
            var gasFiredPowerplant = new Powerplant()
            {
                Type = PowerplantType.gasfired,
                Efficiency = 0.53m
            };

            var fuelCost = new FuelCost()
            {
                GasCost = 13.4m,
                Co2 = 20m
            };

            // Act
            gasFiredPowerplant.UpdateCostPerMwhAndPMaxAvailable(fuelCost);

            // Assert
            gasFiredPowerplant.CostPerMWh.Should().Be(91.94968553459119496855345912M);
        }

        [Fact]
        public void SetP_BetweenValidValues_ExpectedPHasTheValue()
        {
            // Arrange
            var powerplant = new Powerplant()
            {
                PMin = 100,
                PMax = 200,
            };

            // Act
            powerplant.SetP(100);

            // Assert
            powerplant.P.Should().Be(100);
        }

        [Fact]
        public void SetP_LessThanPMin_ShouldThrowValidationException()
        {
            // Arrange
            var powerplant = new Powerplant()
            {
                PMin = 100,
                PMax = 200,
            };

            // Act
            Action action = () => powerplant.SetP(50);

            // Assert
            action.Should().ThrowExactly<ValidationException>()
                .WithMessage($"Can't produce this potency(50) in this powerplant!");
        }

        [Fact]
        public void SetP_GreaterThanPMax_ShouldThrowValidationException()
        {
            // Arrange
            var powerplant = new Powerplant()
            {
                PMin = 100,
                PMax = 200,
            };

            // Act
            Action action = () => powerplant.SetP(250);

            // Assert
            action.Should().ThrowExactly<ValidationException>()
                .WithMessage($"Can't produce this potency(250) in this powerplant!");
        }
    }
}