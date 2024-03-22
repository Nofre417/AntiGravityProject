using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Receiver
{
    public class ReceiverInterface : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _boxesAmountText;
        [SerializeField] private Image _image;
        
        public string BoxesAmount
        {
            set =>  _boxesAmountText.text = value;
        }
        public Color Color
        {
            set => _image.color = value;
        }
    }
}