using System;
using System.Collections.Generic;
using UnityEngine;
using WorldEvents;
using WorldEvents.Interfaces;
using Random = UnityEngine.Random;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    [SerializeField] private Transform ocean;
    
    private List<IWorldEvent> _worldEvents;
    
    public enum GameMode
    {
        COMPETITIVE,
        COOPERATIVE,
    }
    public GameMode gamemode;

    public CountdownTimer countdownTimer;

    public bool gameOver = false;

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

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        _worldEvents = new List<IWorldEvent>
        {
            new FloodEvent(ocean, 0.25f),
            new FloodEvent(ocean, 0.25f),
            new FloodEvent(ocean, 0.25f),
            new FloodEvent(ocean, 0.25f),
            new FloodEvent(ocean, 0.25f),
            new FloodEvent(ocean, 0.25f)
            /*new FallingLogsEvent(),
            new FallingRocksEvent(),
            new SlipperySlopeEvent(),
            new NarrowingPathEvent(),
            new SwapPlayerPositionsEvent()*/
        };
    }

    private void Update()
    {
        _worldEvents[0].Update();
    }

    private void TriggerGameEvent(int diceResult)
    {
        //_worldEvents[0].Activate();
        //_worldEvents[Random.Range(0, 6)].Activate();
        _worldEvents[diceResult-1].Activate(); 
    }

    public void GameOver(string winner)
    {
        GameManager.Instance.gameOver = true;
        countdownTimer.timerOn = false;
        countdownTimer.roundEndText.text = winner;
        countdownTimer.roundEndText.enabled = true;
    }
}
