using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public static GameManager Instance { get; set; } = null;

    private void Awake()
    {
        if (Instance == null)
            Instance = (GameManager)FindObjectOfType(typeof(GameManager));
        else
            Instance = this;
    }
    void Update()
    {
        
    }
}
