using Gravity;
using TMPro;
using UnityEngine;

namespace Border
{
    public class GateController : MonoBehaviour
    { 
        [SerializeField] private TextMeshProUGUI buttonText;
        [SerializeField] private GravityZoneController _gravityController;
        [SerializeField] private EnjectorController.EnjectorController _enjectorController;

        public bool IsOpen
        {
            get => _collider.isTrigger;

            set
            {
                _collider.isTrigger = value;
                OpenCloseGate();
            }
        }
        
        private Collider _collider;

        private const string CloseText = "Close Gate";
        private const string OpenText = "Open Gate";

        private void Start()
        {
            _collider = gameObject.GetComponent<BoxCollider>();
            _enjectorController.IsOpen = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Box"))
            {
                other.gameObject.layer = 10;
            }
        }

        public void OpenCloseGate()
        {
            if (_collider.isTrigger)
            {
                _collider.isTrigger = false;
                _enjectorController.IsOpen = false;
                buttonText.text = OpenText;
            }
            else
            {
                _collider.isTrigger = true;
                _enjectorController.IsOpen = true;
                _gravityController.IsGravity = true;
                buttonText.text = CloseText;
            }
        }

        public void OpenGate() => IsOpen = true;

        public void CloseGate() => IsOpen = false;
    }
}