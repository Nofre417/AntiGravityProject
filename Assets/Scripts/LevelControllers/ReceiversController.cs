using System.Collections.Generic;
using Box;
using UnityEngine;
using Random = System.Random;

namespace LevelControllers
{
    public class ReceiversController : MonoBehaviour
    {
        [Header("Level Controller")] 
        [SerializeField] private LevelController _levelController;
        
        [Header("BoxesSO")] 
        [SerializeField] private List<BoxSO> _boxesSOList;
        
        [Header("Receivers")]
        [SerializeField] private List<Receiver.Receiver> _receiversList;

        private Random _random;
        
        public void SetReceiversTargets()
        {
            for (int i = 0; i < _receiversList.Count; i++)
            {
                _receiversList[i].BoxSO = _boxesSOList[i];
            }
        }

        private List<BoxSO> ShaffleList(List<BoxSO> boxesList)
        {
            List<BoxSO> result = new();
            
            _random = new();
            int length = boxesList.Count - 1;
            bool flag = true;

            if (length > 1)
            {
                do
                {
                    int randomValue = GetRandomValue();

                    if (!result.Contains(boxesList[randomValue]))
                    {
                        result.Add(boxesList[randomValue]);
                    }
                    
                } while (result.Count < boxesList.Count);
            }

            int GetRandomValue()
            {
                return _random.Next(0, length);
            }

            print(result.Count);
            return result;
        }
        
        public void IncrementScore(int score) => _levelController.Score += score;
        public void IncrementBoxesAmount(int boxes) => _levelController.BoxAmount += boxes;
    }
}