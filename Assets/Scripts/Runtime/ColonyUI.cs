using TMPro;
using UnityEngine;

namespace ColonySurvival.Runtime
{
    public class ColonyUI : MonoBehaviour
    {
        [SerializeField] private ColonyController colonyController;

        [SerializeField] private TextMeshProUGUI foodText;
        [SerializeField] private TextMeshProUGUI waterText;
        [SerializeField] private TextMeshProUGUI foodDaysText;
        [SerializeField] private TextMeshProUGUI waterDaysText;
        [SerializeField] private TextMeshProUGUI dayText;
        [SerializeField] private TextMeshProUGUI statusText;

        private void Update()
        {
            if (colonyController == null || colonyController.ColonySimulation == null)
            {
                return;
            }

            var simulation = colonyController.ColonySimulation;

            foodText.text = $"Food: {simulation.FoodStored:0.0}";
            waterText.text = $"Water: {simulation.WaterStored:0.0}";

            if (float.IsPositiveInfinity(simulation.FoodDaysRemaining()))
            {
                foodDaysText.text = "Food remaining: Infinity";
            }
            else
            {
                foodDaysText.text = $"Food remaining: {simulation.FoodDaysRemaining():0.0} days";
            }

            if (float.IsPositiveInfinity(simulation.WaterDaysRemaining()))
            {
                waterDaysText.text = "Water remaining: Infinity";
            }
            else
            {
                waterDaysText.text = $"Water remaining: {simulation.WaterDaysRemaining():0.0} days";
            }

            dayText.text = $"Day: {simulation.CurrentDay}";

            if (simulation.IsStarving())
            {
                statusText.text = "COLONY: Starving";
            }
            else
            {
                statusText.text = "Colony: Healthy";
            }
        }
    }
}
