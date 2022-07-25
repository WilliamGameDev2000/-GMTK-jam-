using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSpawn : MonoBehaviour
{
    [SerializeField] GameObject DicePrefab;

    public void SpawnDice(Vector3 position, Quaternion rotation)
    {
        Instantiate(DicePrefab, position, rotation);
    }
}
