using System;
using System.Collections.Generic;
using UnityEngine;
using WorldEvents.Interfaces;

namespace WorldEvents
{
    public class WorldEventManager : MonoBehaviour
    {
        public static WorldEventManager Instance;
        public Action<string> OnWorldEventTriggered;
        [SerializeField] private Transform ocean;
        
        private List<IWorldEvent> _worldEvents;
        
        private void OnEnable()
        {
            DiceCheckZone.Instance.OnDiceRolled += TriggerGameEvent; 
        }

        private void OnDisable()
        {
            DiceCheckZone.Instance.OnDiceRolled -= TriggerGameEvent;
        }
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Debug.LogError("There should only be one instance of the WorldEventManager!");
                Destroy(gameObject);
            }
        }
        
        private void Start()
        {
            _worldEvents = new List<IWorldEvent>
            {
                new FloodEvent(ocean, 0.5f),
                new FallingLogsEvent(),
                new FallingRocksEvent(),
                new SlipperySlopeEvent(),
                new NarrowingPathEvent(),
                new LargeBouldersEvent()
            };
        }

        private void Update()
        {
            for (int i = 0; i < _worldEvents.Count; i++)
            {
                _worldEvents[i].Update();
            }
        }

        private void TriggerGameEvent(int diceResult)
        {
            _worldEvents[diceResult-1].Activate(); 
            OnWorldEventTriggered?.Invoke(_worldEvents[diceResult-1].ToString());
        }
    }
}
