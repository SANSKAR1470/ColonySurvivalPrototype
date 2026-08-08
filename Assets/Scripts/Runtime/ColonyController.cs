using UnityEngine;
using ColonySurvival.Core;

namespace ColonySurvival.Runtime
{
    public class ColonyController : MonoBehaviour
    {
        private ColonySimulation simulation;

        private float timer;

        private void Start()
        {
            PopulationConfiguration population = JSONLoader.Load<PopulationConfiguration>("population.json");
            ConsumptionConfiguration consumption = JSONLoader.Load<ConsumptionConfiguration>("consumption.json");
            simulation = new ColonySimulation(population, consumption);
            Debug.Log("Colony simulation started.");
        }

        private void Update()
        {
            if (simulation == null)
            {
                return;
            }

            timer += Time.deltaTime;

            if (timer >= 1f)
            {
                timer -= 1f;

                simulation.AdvanceDay();

                Debug.Log($"Day {simulation.CurrentDay} | " + $"Food: {simulation.FoodStored} | " + $"Water: {simulation.WaterStored}");
            }
        }
    }
}