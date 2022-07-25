using System;
using System.Collections.Generic;
using UnityEngine;
using WorldEvents;
using WorldEvents.Interfaces;

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
            new FallingLogsEvent(),
            new SlipperySlopeEvent(),
            new FallingLogsEvent(),
            new SlipperySlopeEvent(),
            new FallingLogsEvent(),
            new SlipperySlopeEvent(),
        };
    }
    
    public void TriggerGameEvent(int diceResult)
    {
        Debug.Log("Dice result: " + diceResult);
        _worldEvents[diceResult-1].Activate(); 
        /*if (diceResult < 7 || diceResult > -1)
        {*/
            
        /*}*/
    }
}
