using TMPro;
using UnityEngine;

namespace Receiver
{
    public class ReceiverInterface : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _companyNameText;
        [SerializeField] private TextMeshProUGUI _boxesAmountText;

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
        
        private string _companyName;
        private string _boxesAmount;
    }
}