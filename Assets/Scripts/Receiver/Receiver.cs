using Box;
using LevelControllers;
using UnityEngine;

namespace Receiver
{
    public class Receiver : MonoBehaviour
    {
        [SerializeField] private ReceiversController _receiversController;
        [SerializeField] private ReceiverInterface _receiverInterface;

        public BoxSO BoxSO
        {
            get => _boxSo;
            set
            {
                _boxSo = value;
                _receiverInterface.CompanyName = _boxSo.companyName;
                _receiverInterface.BoxesAmount = $"{_receivedBoxesAmount}/{_avaliableBoxesAmount}";
            }
        }
        
        private BoxSO _boxSo;

        private int _receivedBoxesAmount = 0;
        private int _avaliableBoxesAmount = 0;

        public void CompareEnteredBox(Box.Box box)
        {
            if (box.Id == _boxSo.id)
            {
                _receivedBoxesAmount++;
                
                _receiversController.IncrementScore(10);
                _receiversController.IncrementBoxesAmount(1);
                
                UpdateInterface();
            }
        }

        private void UpdateInterface()
        {
            _receiverInterface.BoxesAmount = $"{_avaliableBoxesAmount}/{_receivedBoxesAmount}";
        }
    }
}