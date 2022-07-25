using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            State currentState = GameStateManager.Instance.CurrentState;
            State NewState = currentState == State.Gameplay ? State.Paused : State.Gameplay;

            GameStateManager.Instance.SetState(NewState);
        }
    }
}
