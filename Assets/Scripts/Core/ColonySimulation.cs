using System;

namespace ColonySurvival.Core
{
    public class ColonySimulation
    {
        public int Villagers { get; private set; }
        public float FoodPerVillagerPerDay { get; private set; }
        public float WaterPerVillagerPerDay { get; private set; }

        public float FoodStored { get; private set; }
        public float WaterStored { get; private set; }

        public int CurrentDay { get; private set; }

        public float DailyFoodConsumption()
        {
            return Villagers * FoodPerVillagerPerDay;
        }

        public float DailyWaterConsumption()
        {
            return Villagers * WaterPerVillagerPerDay;
        }

        public float FoodDaysRemaining()
        {
            if (DailyFoodConsumption() == 0)
            {
                return float.PositiveInfinity;
            }

            return FoodStored / DailyFoodConsumption();
        }

        public float WaterDaysRemaining()
        {
            if (DailyWaterConsumption() == 0)
            {
                return float.PositiveInfinity;
            }

            return WaterStored / DailyWaterConsumption();
        }

        public bool IsStarving()
        {
            return FoodStored <= 0 || WaterStored <= 0;
        }

        public ColonySimulation(PopulationConfiguration populationConfiguration, ConsumptionConfiguration consumptionConfiguration)
        {
            Villagers = populationConfiguration.villagers;

            FoodStored = populationConfiguration.startingFood;
            WaterStored = populationConfiguration.startingWater;

            FoodPerVillagerPerDay = consumptionConfiguration.foodPerVillager;
            WaterPerVillagerPerDay = consumptionConfiguration.waterPerVillager;

            CurrentDay = 0;
        }

        public void AdvanceDay()
        {
            CurrentDay++;

            FoodStored -= DailyFoodConsumption();
            WaterStored -= DailyWaterConsumption();

            if (FoodStored < 0)
            {
                FoodStored = 0;
            }

            if (WaterStored < 0)
            {
                WaterStored = 0;
            }
        }
    }
}