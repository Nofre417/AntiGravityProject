using TMPro;
using UnityEngine;

namespace LevelControllers.View
{
    public class LevelStatsView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _boxesAmountText;

        public string Score
        {
            set => _scoreText.text = value;
        }

        public string BoxesAmount
        {
            set => _boxesAmountText.text = value;
        }
    }
}