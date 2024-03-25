using TMPro;
using UnityEngine;

namespace LevelControllers.View
{
    public class LosePanel : MonoBehaviour
    {
        [SerializeField] private LevelController _levelController;
        [SerializeField] private TextMeshProUGUI _loseValueText;
        public int LoseValue
        {
            set => _loseValueText.text = $"{value}";
        }
        
        private bool _statusPanel = false;

        public void SwitchPanel(bool status)
        {
            this.gameObject.SetActive(status);
        }
    }
}