using Gravity;
using TMPro;
using UnityEngine;

namespace Border
{
    public class GateController : MonoBehaviour
    { 
        [SerializeField] private TextMeshProUGUI buttonText;

        [SerializeField] private GravityZoneController _gravityZoneController;

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
                buttonText.text = OpenText;
            }
            else
            {
                _collider.isTrigger = true;
                _gravityZoneController.IsGravity = true;
                buttonText.text = CloseText;
            }
        }
    }
}