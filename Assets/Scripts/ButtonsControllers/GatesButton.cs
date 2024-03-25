using Border;
using Gravity;
using LevelControllers;
using UnityEngine;

namespace ButtonsControllers
{
    public class GatesButton : MonoBehaviour
    {
        [SerializeField] private LevelController _levelController;
        
        [SerializeField] private GateController _gateController;
        [SerializeField] private GravityZoneController _gravityZoneController;
        
        [SerializeField] private GameObject _activeState;
        [SerializeField] private GameObject _disactiveState;

        private bool _isActive;

        public void SetButtonStatus()
        {
            if (_isActive)
            {
                _isActive = false;
                _activeState.SetActive(false);
                _disactiveState.SetActive(true);
            }
            else if(!_isActive && _gravityZoneController.IsGravity)
            {
                _isActive = true;
                _activeState.SetActive(true);
                _disactiveState.SetActive(false);
                
            }
            
            _gateController.IsOpen = !_isActive;
            _levelController.PlayClickSound();
        }
    }
}