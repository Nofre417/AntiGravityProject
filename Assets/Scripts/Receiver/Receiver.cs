using Box;
using LevelControllers;
using UnityEngine;

namespace Receiver
{
    public class Receiver : MonoBehaviour
    {
        [SerializeField] private ReceiversController _receiversController;
        [SerializeField] private ReceiverInterface _receiverInterface;
        [SerializeField] private int _scorePerBox = 10;

        public BoxSO BoxSO
        {
            get => _boxSo;
            set
            {
                _boxSo = value;
                _receiverInterface.BoxesAmount = $"{_receivedBoxesAmount}";
                _receiverInterface.Color = _boxSo.material.color;
            }
        }

        public int BoxesAmount
        {
            set
            {
                _receivedBoxesAmount = value;
                UpdateInterface();
            } 
        }
        
        private BoxSO _boxSo;

        private int _receivedBoxesAmount = 0;

        public void CompareEnteredBox(Box.Box box)
        {
            if (box.Id == _boxSo.id)
            {
                _receivedBoxesAmount++;
                
                _receiversController.IncrementScore(_scorePerBox);
                _receiversController.IncrementBoxesAmount(1);
                
                UpdateInterface();
            }
            else
            {
                _receiversController.IncrementWrongBoxes(1);
            }
            
            _receiversController.PlayReceiverSound();
        }

        private void UpdateInterface()
        {
            _receiverInterface.BoxesAmount = $"{_receivedBoxesAmount}";
        }
    }
}