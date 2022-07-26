using System;
using System.Collections.Generic;
using UnityEngine;
using WorldEvents;
using WorldEvents.Interfaces;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    private List<IWorldEvent> _worldEvents;
    
    private void OnEnable()
    {
        DiceCheckZone.Instance.DiceRolled += TriggerGameEvent; 
    }

    private void OnDisable()
    {
        DiceCheckZone.Instance.DiceRolled -= TriggerGameEvent;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;   
        }
        else
        {
            Debug.LogError("There should only be one instance of the GameManager!");
        }
    }

    private void Start()
    {
        _worldEvents = new List<IWorldEvent>
        {
            new FloodEvent(),
            new FallingLogsEvent(),
            new FallingRocksEvent(),
            new SlipperySlopeEvent(),
            new NarrowingPathEvent(),
            new SwapPlayerPositionsEvent()
        };

        PlayerSpawner.Instance.SpawnPlayers();
    }

    private void TriggerGameEvent(int diceResult)
    {
        _worldEvents[Random.Range(0, 6)].Activate();
        //_worldEvents[diceResult-1].Activate(); 
    }
}
