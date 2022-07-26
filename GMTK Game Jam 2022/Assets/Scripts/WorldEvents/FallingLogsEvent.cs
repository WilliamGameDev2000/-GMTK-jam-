using UnityEngine;
using WorldEvents.Interfaces;

namespace WorldEvents
{
    public class FallingLogsEvent : IWorldEvent
    {
       // private GameObje
        
        /*private void FallingLogsEvent(Gameobject logPrefab, float throwerPos, float spawnRate, int numOfLogs)
        {
            
        }*/
        
        public void Activate()
        {
            Debug.Log("FallingLogsEvent");
        }

        public void Update()
        {
            
        }
    }
}

