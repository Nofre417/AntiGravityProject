using System;
using UnityEngine;

namespace LevelControllers
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private ReceiversController _receiversController;
        public int Score
        {
            get => _score;
            set => _score = value;
            
        }
        public int BoxAmount
        {
            get => _boxAmount;
            set => _boxAmount = value;
        }
        
        private int _score = 0;
        private int _boxAmount = 0;

        private void Start()
        {
            SetReceivers();
        }

        private void SetReceivers()
        {
            if (_receiversController != null)
            {
                _receiversController.SetReceiversTargets();
            }
        }
    }
}