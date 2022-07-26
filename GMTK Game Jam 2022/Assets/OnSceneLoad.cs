using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSceneLoad : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerSpawner.Instance.SpawnPlayers();
    }
}
