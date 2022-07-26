using UnityEngine;
using WorldEvents.Interfaces;

namespace WorldEvents
{
    public class NarrowingPathEvent : IWorldEvent
    {
        public void Activate()
        {
            Debug.Log("NarrowingPathEvent");
        }

        public void Update()
        {
            
        }
    }
}
