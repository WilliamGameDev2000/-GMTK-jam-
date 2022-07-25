using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZone : MonoBehaviour
{
    public static DiceCheckZone Instance;
    private Vector3 _velocity;
    public int diceResult;
    public Action<int> DiceRolled;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There should only be one instance of the DiceCheckZone!");
        }
    }

    private void FixedUpdate()
    {
        _velocity = DiceRoll.DiceVel;
    }

    private void OnTriggerStay(Collider col)
    {
        if (_velocity.x == 0f && _velocity.y == 0f && _velocity.z ==0f)
        {
            switch(col.gameObject.name)
            {
                case "side1":
                    {
                        Debug.Log("Side6 Has landed");
                        diceResult = 6;      
                        break; 
                    }
                case "side2":
                    {
                        Debug.Log("Side5 Was rolled");
                        diceResult = 5;
                        break;
                    }
                case "side3":
                    {
                        Debug.Log("Side4 Facing up");
                        diceResult = 4;
                        break;
                    }
                case "side4":
                    {
                        Debug.Log("Side3 Is skyward");
                        diceResult = 3;
                        break;
                    }
                case "side5":
                    {
                        Debug.Log("Side2 Is live");
                        diceResult = 2;
                        break;
                    }
                case "side6":
                    {
                        Debug.Log("Side1 Our result");
                        diceResult = 1;
                        break;
                    }
            }
            DiceRolled?.Invoke(diceResult);
            Activate(false);
        }
    }

    public void Activate(bool activate)
    {
        gameObject.SetActive(activate);
    }
}
