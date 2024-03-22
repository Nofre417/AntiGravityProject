using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Box
{
    public class BoxSpawner : MonoBehaviour
    {
        [Header("Prefab")]
        [SerializeField] private GameObject _boxPrefab;
        
        [Header("Spawn Point / Parent")]
        [SerializeField] private Transform _spawnPoint;

        [Header("Boxes SO List")] 
        [SerializeField] private List<BoxSO> _boxesScriptableObjectsList;

        [Range(1, 30)] [SerializeField] private float _spawnTime;
        [Range(1, 5)] [SerializeField] private int _spawnAmount;

        [SerializeField] private bool _toSpawn;

        public bool ToSpawn
        {
            get => _toSpawn;
            set => _toSpawn = value;
        }
        
        private float _timer;
        private int _randomSpawnAmount;
        
        Random _random = new();
        

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _spawnTime)
            {
                if (_toSpawn)
                {
                    if (_spawnAmount > 1)
                    {
                        _randomSpawnAmount = _random.Next(1, _spawnAmount);
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

                    _spawnTime -= _spawnTime / 1000f;
                }

                _timer -= _spawnTime;
            }
        }

        private void SpawnBox()
        {
            GameObject instance = Instantiate(_boxPrefab, _spawnPoint, false);

            Box box = instance.GetComponent<Box>();

            BoxSO randomBoxSO = _boxesScriptableObjectsList[_random.Next(0, _boxesScriptableObjectsList.Count)];
            
            box.Initialisation(randomBoxSO.id, randomBoxSO.material);
        }
    }
}