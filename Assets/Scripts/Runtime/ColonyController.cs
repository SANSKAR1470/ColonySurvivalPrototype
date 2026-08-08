using UnityEngine;
using ColonySurvival.Core;

namespace ColonySurvival.Runtime
{
    public class ColonyController : MonoBehaviour
    {
        private ColonySimulation colonySimulation;
        public ColonySimulation ColonySimulation => colonySimulation;

        private float timer;

        private void Start()
        {
            PopulationConfiguration population = JSONLoader.Load<PopulationConfiguration>("population.json");
            ConsumptionConfiguration consumption = JSONLoader.Load<ConsumptionConfiguration>("consumption.json");
            colonySimulation = new ColonySimulation(population, consumption);
        }

        private void Update()
        {
            if (colonySimulation == null)
            {
                return;
            }

            timer += Time.deltaTime;

            if (timer >= 1f)
            {
                timer -= 1f;

                colonySimulation.AdvanceDay();
            }
        }
    }
}