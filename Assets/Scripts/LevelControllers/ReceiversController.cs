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
            int count = 0;

            List<BoxSO> shuffledList = ShuffleList(_boxesSOList);
            

            foreach (var box in shuffledList)
            {
                _receiversList[count].BoxSO = box;
                _receiversList[count + 1].BoxSO = box;
                count += 2;
            }
        }

        private List<BoxSO> ShuffleList(List<BoxSO> listToShuffle)
        {
            List<BoxSO> result = listToShuffle;

            for (int i = 0; i < listToShuffle.Count; i++)
            {
                _random = new();
                int j = _random.Next(i, listToShuffle.Count);

                (listToShuffle[i], listToShuffle[j]) = (listToShuffle[j], listToShuffle[i]);
            }

            return result;
        }

        public void IncrementScore(int score) => _levelController.Score += score;
        public void IncrementBoxesAmount(int boxes) => _levelController.BoxAmount += boxes;
        public void IncrementWrongBoxes(int wrongBoxes) => _levelController.WrongBoxes += wrongBoxes;
    }
}