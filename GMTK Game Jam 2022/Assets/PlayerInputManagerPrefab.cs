using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManagerPrefab : MonoBehaviour
{
    [SerializeField] GameObject throwerPrefab;
    [SerializeField] GameObject dodgerPrefab;

    void Update()
    {
        if (PlayerInputManager.instance.playerCount == 0)
        {
            PlayerInputManager.instance.playerPrefab = throwerPrefab;
        }
        else
        {
            PlayerInputManager.instance.playerPrefab = dodgerPrefab;
        }
    }
}
