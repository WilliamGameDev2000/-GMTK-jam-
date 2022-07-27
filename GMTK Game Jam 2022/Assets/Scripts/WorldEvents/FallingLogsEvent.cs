using UnityEngine;
using WorldEvents.Interfaces;

namespace WorldEvents
{
    public class FallingLogsEvent : IWorldEvent
    {
        private GameObject _logPrefab;
        private Transform[] _spawnPos;
        private float _spawnRate;
        private int _numOfLogs;
        private int _logsSpawned;
        private bool _isActive;
        private float _timeSinceLastSpawn;
        
        public FallingLogsEvent(GameObject logPrefab, Transform[] spawnPos , float spawnRate, int numOfLogs)
        {
            _logPrefab = logPrefab;
            _spawnPos = spawnPos;
            _spawnRate = spawnRate;
            _numOfLogs = numOfLogs;
            _isActive = false;
        }
        
        public void Activate()
        {
            _logsSpawned = 0;
            _isActive = true;
        }

        public void Update()
        {
            if (_isActive && Time.time > _timeSinceLastSpawn && _logsSpawned < _numOfLogs)
            {
                GameObject.Instantiate(_logPrefab, _spawnPos[Random.Range(0, _spawnPos.Length)].position, Quaternion.identity);
                _logsSpawned++;
                _timeSinceLastSpawn = Time.time + _spawnRate;
            }

            if (_logsSpawned >= _numOfLogs)
            {
                _isActive = false;
            }
        }
    }
}

