using Gravity;
using TMPro;
using UnityEngine;

namespace Border
{
    public class GateController : MonoBehaviour
    { 
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

        private void OpenCloseGate()
        {
            if (_collider.isTrigger)
            {
                _collider.isTrigger = false;
                _enjectorController.IsOpen = false;
            }
            else
            {
                _collider.isTrigger = true;
                _enjectorController.IsOpen = true;
                _gravityController.IsGravity = true;
            }
        }
    }
}