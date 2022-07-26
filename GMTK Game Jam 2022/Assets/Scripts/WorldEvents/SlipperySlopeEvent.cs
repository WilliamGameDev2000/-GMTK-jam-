using UnityEngine;
using WorldEvents.Interfaces;

namespace WorldEvents
{
    public class SlipperySlopeEvent : IWorldEvent
    {
        public void Activate()
        {
            Debug.Log("SlipperySlopeEvent");
        }
    }
}
