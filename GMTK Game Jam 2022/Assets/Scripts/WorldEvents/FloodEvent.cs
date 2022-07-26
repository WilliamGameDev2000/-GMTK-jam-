using UnityEngine;
using WorldEvents.Interfaces;

namespace WorldEvents
{
    public class FloodEvent : IWorldEvent
    {
        public void Activate()
        {
            Debug.Log("FloodEvent");
        }
    }
}
