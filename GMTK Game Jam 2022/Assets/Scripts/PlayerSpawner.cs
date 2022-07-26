using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject throwerPrefab;
    [SerializeField] private GameObject dodgerPrefab;

    [HideInInspector] public int playerID = 0;

    public static PlayerSpawner Instance { get; set; }

    public Transform throwerSpawnPoint;
    public List<Transform> dodgerSpawnPoints = new List<Transform>();

    public int numberOfPlayers = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There should only be one instance of " + this.name);
            Destroy(Instance);
        }
    }

    public void SetNumberOfPlayers(int _numberOfPlayers)
    {
        numberOfPlayers = _numberOfPlayers;
    }

    public void SpawnPlayers()
    {
        if(numberOfPlayers <= 1)
        {
            Debug.LogError("Number of players must be more than 1");
            return;
        }

        //int connectedGamepads = Gamepad.all.Count;

        for (int i = 0; i < numberOfPlayers; i++)
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

            dodgerSpawnPoints[i].position = new Vector3(25.32f + (i * 2f), 1.85f, -10.97f);
            throwerSpawnPoint.position = new Vector3(28f, 21.81f, 27.2f);
            playerID++;
        }
    }
}
