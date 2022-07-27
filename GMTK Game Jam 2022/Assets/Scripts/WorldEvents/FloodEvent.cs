using UnityEngine;
using WorldEvents.Interfaces;

namespace WorldEvents
{
    public class FloodEvent : IWorldEvent
    {
        private Transform _ocean;
        private float _riseSpeed;
        private bool _isActive;
        
        public FloodEvent(Transform ocean, float riseSpeed)
        {
            _ocean = ocean;
            _riseSpeed = riseSpeed;
            _isActive = false;
        }
        
        public void Activate()
        {
            _isActive = true;
        }

        public void Update()
        {
            if (_isActive)
            {
                _ocean.position = new Vector3(_ocean.position.x, _ocean.position.y + _riseSpeed * Time.deltaTime, _ocean.position.z);
            }
        }
    }
}
