using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZone : MonoBehaviour
{
    public static DiceCheckZone Instance;
    public Action<int> OnDiceRolled;

    private Vector3 _velocity;
    private int _diceResult = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There should only be one instance of the DiceCheckZone!");
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        _velocity = DiceBoulder.DiceVel;
    }

    private void OnTriggerStay(Collider col)
    {
        switch (col.tag)
        {
            case "side1":
                {
                    //Debug.Log("Side6 Has landed");
                    _diceResult = 6;
                    OnDiceRolled?.Invoke(_diceResult);
                    break;
                }
            case "side2":
                {
                    //Debug.Log("Side5 Was rolled");
                    _diceResult = 5;
                    OnDiceRolled?.Invoke(_diceResult);
                    break;
                }
            case "side3":
                {
                    //Debug.Log("Side4 Facing up");
                    _diceResult = 4;
                    OnDiceRolled?.Invoke(_diceResult);
                    break;
                }
            case "side4":
                {
                    //Debug.Log("Side3 Is skyward");
                    _diceResult = 3;
                    OnDiceRolled?.Invoke(_diceResult);
                    break;
                }
            case "side5":
                {
                    //Debug.Log("Side2 Is live");
                    _diceResult = 2;
                    OnDiceRolled?.Invoke(_diceResult);
                    break;
                }
            case "side6":
                {
                    //Debug.Log("Side1 Our result");
                    _diceResult = 1;
                    OnDiceRolled?.Invoke(_diceResult);
                    break;
                }
        }
        Activate(false);
    }

    public void Activate(bool activate)
    {
        gameObject.SetActive(activate);
    }
}
