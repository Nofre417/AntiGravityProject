using Box;
using UnityEngine;

namespace Zones
{
    public class BoxesQueueController : MonoBehaviour
    {
        [SerializeField] private BoxSpawner _boxSpawner;
        [SerializeField] private int _maxBoxesQueueAmount = 10;
        private int _boxesAmount = 0;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Box"))
            {
                _boxesAmount++;

                if (_boxesAmount >= _maxBoxesQueueAmount)
                {
                    _boxSpawner.ToSpawn = false;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Box"))
            {
                _boxesAmount--;

                if (_boxesAmount < _maxBoxesQueueAmount)
                {
                    _boxSpawner.ToSpawn = true;
                }
            }
        }
    }
}