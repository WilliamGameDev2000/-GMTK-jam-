using UnityEngine;
using WorldEvents.Interfaces;

namespace WorldEvents
{
    public class FallingRocksEvent : IWorldEvent
    {
        public void Activate()
        {
            Debug.Log("FallingRocksEvent");
        }
    }
}
