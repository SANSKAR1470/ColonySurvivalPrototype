using NUnit.Framework;
using ColonySurvival.Core;

namespace ColonySurvival.Tests
{
    public class ColonySimulationTests
    {
        private PopulationConfiguration population;
        private ConsumptionConfiguration consumption;

        [SetUp]
        public void SetUp()
        {
            population = new PopulationConfiguration
            {
                villagers = 10,
                startingFood = 100,
                startingWater = 100
            };

            consumption = new ConsumptionConfiguration
            {
                foodPerVillager = 2,
                waterPerVillager = 3
            };
        }

        [Test]
        public void SimulationStartsWithConfiguredValues()
        {
            var simulation = new ColonySimulation(population, consumption);

            Assert.AreEqual(10, simulation.Villagers);
            Assert.AreEqual(100f, simulation.FoodStored);
            Assert.AreEqual(100f, simulation.WaterStored);
            Assert.AreEqual(0, simulation.CurrentDay);
        }

        [Test]
        public void AdvanceDayConsumesFoodAndWater()
        {
            var simulation = new ColonySimulation(population, consumption);

            simulation.AdvanceDay();

            Assert.AreEqual(1, simulation.CurrentDay);
            Assert.AreEqual(80f, simulation.FoodStored);
            Assert.AreEqual(70f, simulation.WaterStored);
        }

        [Test]
        public void ResourcesDoNotGoBelowZero()
        {
            population.startingFood = 5;
            population.startingWater = 5;

            var simulation = new ColonySimulation(population, consumption);

            simulation.AdvanceDay();

            Assert.AreEqual(0f, simulation.FoodStored);
            Assert.AreEqual(0f, simulation.WaterStored);
        }

        [Test]
        public void ColonyIsStarvingWhenResourceReachesZero()
        {
            population.startingFood = 5;

            var simulation = new ColonySimulation(population, consumption);

            simulation.AdvanceDay();

            Assert.IsTrue(simulation.IsStarving());
        }

        [Test]
        public void DaysRemainingAreCalculatedCorrectly()
        {
            var simulation = new ColonySimulation(population, consumption);

            Assert.AreEqual(5f, simulation.FoodDaysRemaining());
            Assert.AreEqual(3.333333f, simulation.WaterDaysRemaining(), 0.001f);
        }

        [Test]
        public void ZeroConsumptionMeansResourcesDoNotRunOut()
        {
            consumption.foodPerVillager = 0;
            consumption.waterPerVillager = 0;

            var simulation = new ColonySimulation(population, consumption);

            Assert.AreEqual(float.PositiveInfinity, simulation.FoodDaysRemaining());
            Assert.AreEqual(float.PositiveInfinity, simulation.WaterDaysRemaining());
        }
    }
}