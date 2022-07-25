using System.Collections.Generic;
using UnityEngine;
using WorldEvents;
using WorldEvents.Interfaces;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    private List<IWorldEvent> _worldEvents;

    private void Awake()
    {
        if (Instance == null)
            Instance = (GameManager)FindObjectOfType(typeof(GameManager));
        else
            Instance = this;
    }
  
    private void Start()
    {
        _worldEvents = new List<IWorldEvent>()
        {
            new FallingLogsEvent(),
            new SlipperySlopeEvent()
        };
    }

    //public Action<int> onDiceRoll;
    public void TriggerGameEvent(int diceResult)
    {
        if (diceResult < _worldEvents.Count || diceResult > -1)
        {
            _worldEvents[diceResult].Activate(); 
        }
    }
}
