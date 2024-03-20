using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Receiver
{
    public class ReceiverInterface : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _companyNameText;
        [SerializeField] private TextMeshProUGUI _boxesAmountText;
        [SerializeField] private Image _image;

        public string CompanyName
        {
            set
            {
                _companyName = value;
                _companyNameText.text = _companyName;
            }
        }
        public string BoxesAmount
        {
            set
            {
                _boxesAmount = value;
                _boxesAmountText.text = _boxesAmount;
            }
        }
        public Color Color
        {
            set => _image.color = value;
        }
        
        private string _companyName;
        private string _boxesAmount;
    }
}