using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManagerPrefab : MonoBehaviour
{
    [SerializeField] GameObject throwerPrefab;
    [SerializeField] GameObject dodgerPrefab;

    [HideInInspector] public int playerID = 0;

    public static PlayerInputManagerPrefab Instance { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There should only be one instance of " + this.name);
        }
    }

    private void Start()
    {
        for (int i = 0; i < PlayerInputManager.instance.maxPlayerCount; i++)
        {
            if (PlayerInputManager.instance.playerCount == 0)
            {
                PlayerInput.Instantiate(throwerPrefab, controlScheme: "Keyboard1", pairWithDevice: Keyboard.current);
            }
            else if (PlayerInputManager.instance.playerCount == 1)
            {
                PlayerInput.Instantiate(dodgerPrefab, controlScheme: "keyboard2", pairWithDevice: Keyboard.current);
            }
            else
            {
                PlayerInput.Instantiate(dodgerPrefab, controlScheme: "Gamepad", pairWithDevice: Gamepad.current);
            }

            playerID++;
        }
    }

    void Update()
    {

    }
}
