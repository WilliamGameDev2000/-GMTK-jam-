using UnityEngine;
using WorldEvents.Interfaces;

namespace WorldEvents
{
    public class SwapPlayerPositionsEvent : IWorldEvent
    {
        public void Activate()
        {
            Debug.Log("SwapPlayerPositionsEvent");
        }
    }
}
