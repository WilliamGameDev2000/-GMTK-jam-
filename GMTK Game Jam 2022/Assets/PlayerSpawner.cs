using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject throwerPrefab;
    [SerializeField] private GameObject dodgerPrefab;

    [SerializeField] [Range(1, 3)] public int numberOfDodgers = 1;

    [SerializeField] private Transform throwerSpawnPoint;
    [SerializeField] private List<Transform> dodgerSpawnPoints = new List<Transform>();

    private void Start()
    {
        Instantiate(throwerPrefab, throwerSpawnPoint.position, throwerSpawnPoint.rotation);

        for (int i = 0; i < numberOfDodgers; i++)
        {
            Instantiate(dodgerPrefab, dodgerSpawnPoints[i].position, dodgerSpawnPoints[i].rotation);
        }
    }
}
