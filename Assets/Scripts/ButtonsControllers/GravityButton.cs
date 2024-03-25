using Border;
using Gravity;
using LevelControllers;
using UnityEngine;

namespace ButtonsControllers
{
    public class GravityButton : MonoBehaviour
    {
        [SerializeField] private LevelController _levelController;
        
        [SerializeField] private GravityZoneController _gravityZoneController;
        [SerializeField] private GateController _gateController;
        
        [SerializeField] private GameObject _activeState;
        [SerializeField] private GameObject _disactiveState;

        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                SetButtonStatus();
            }
        }
        
        private bool _isActive;

        public void SetButtonStatus()
        {
            if (_isActive)
            {
                _isActive = false;
                _activeState.SetActive(false);
                _disactiveState.SetActive(true);
            }
            else if(!_isActive && !_gateController.IsOpen)
            {
                _isActive = true;
                _activeState.SetActive(true);
                _disactiveState.SetActive(false);
            }

            _gravityZoneController.IsGravity = !_isActive;
            _levelController.PlayClickSound();
        }
    }
}