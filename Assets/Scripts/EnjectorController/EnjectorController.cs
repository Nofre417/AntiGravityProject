using System;
using UnityEngine;

namespace EnjectorController
{
    public class EnjectorController : MonoBehaviour
    {
        [SerializeField] private GameObject _leftGate;
        [SerializeField] private GameObject _rightGate;

        private Animator _leftGateAnimator;
        private Animator _rightGateAnimator;
        private bool _isOpen;

        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                _isOpen = value;
                SwitchGates(_isOpen);
            }
        }

        private void Start()
        {
            _leftGateAnimator = _leftGate.gameObject.GetComponent<Animator>();
            _rightGateAnimator = _rightGate.gameObject.GetComponent<Animator>();
        }

        private void SwitchGates(bool status)
        {
            if (status)
            {
                _leftGateAnimator.Play("LeftGateOpen");
                _rightGateAnimator.Play("RighGateOpen");
            }
            else
            {
                _leftGateAnimator.Play("LeftGateClose");
                _rightGateAnimator.Play("RighGateCLose");
            }
        }
    }
}