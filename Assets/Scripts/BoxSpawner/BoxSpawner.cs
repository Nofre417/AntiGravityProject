using System;
using System.Collections;
using UnityEngine;
using Random = System.Random;

namespace BoxSpawner
{
    public class BoxSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _boxPrefab;
        [SerializeField] private Transform _spawnPoint;

        [Range(1, 30)] [SerializeField] private float _spawnTime;
        [Range(1, 5)] [SerializeField] private int _spawnAmount;

        [SerializeField] private bool _ToSpawn;

        private float _timer;
        private int _randomSpawnAmount;
        
        Random random = new();

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _spawnTime)
            {
                if (_ToSpawn)
                {
                    if (_spawnAmount > 1)
                    {
                        _randomSpawnAmount = random.Next(1, _spawnAmount);
                    }
                    
                    if (_randomSpawnAmount > 1)
                    {
                        for (int i = 0; i <= _randomSpawnAmount; i++)
                        {
                            SpawnBox();
;                       }
                    }
                    else
                    {
                        SpawnBox();
                    }
                }

                _timer -= _spawnTime;
            }
        }

        private void SpawnBox()
        {
            GameObject instance = Instantiate(_boxPrefab, _spawnPoint, false);
        }

        private void MoveBox(GameObject box)
        {
            Rigidbody rb = box.GetComponent<Rigidbody>();

            Vector3 vector = new Vector3(0f, 10f, 0f);
            
            rb.AddForce(vector, ForceMode.Impulse);
        }
    }
}