using System;

namespace ColonySurvival.Core
{
    [Serializable]
    public class ConsumptionConfiguration
    {
        public float foodPerVillager;
        public float waterPerVillager;
    }

    [Serializable]
    public class PopulationConfiguration
    {
        public int villagers;
        public float startingFood;
        public float startingWater;
    }
}
