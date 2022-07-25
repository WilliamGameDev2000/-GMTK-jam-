using UnityEngine;
using WorldEvents.Interfaces;

namespace WorldEvents
{
    public class FallingLogsEvent : IWorldEvent
    {
        public void Activate()
        {
            Debug.Log("Hello");
        }
    }
}

