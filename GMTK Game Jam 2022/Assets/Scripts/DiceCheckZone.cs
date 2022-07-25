using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZone : MonoBehaviour
{
    public static DiceCheckZone checkZone;
    Vector3 velocity;

    private void Awake()
    {
        if (checkZone == null)
        {
            checkZone = this;
        }
        else
        {
            Destroy(this);
        }
        
    }

    void FixedUpdate()
    {
        velocity = DiceRoll.DiceVel;
    }

    void OnTriggerStay(Collider col)
    {
        if (velocity.x == 0f && velocity.y == 0f && velocity.z ==0f)
        {
            switch(col.gameObject.name)
            {
                case "side1":
                    {
                        Debug.Log("Side6 Has landed");
                        break;
                    }
                case "side2":
                    {
                        Debug.Log("Side5 Was rolled");
                        break;
                    }
                case "side3":
                    {
                        Debug.Log("Side4 Facing up");
                        break;
                    }
                case "side4":
                    {
                        Debug.Log("Side3 Is skyward");
                        break;
                    }
                case "side5":
                    {
                        Debug.Log("Side2 Is live");
                        break;
                    }
                case "side6":
                    {
                        Debug.Log("Side1 Our result");
                        break;
                    }
            }
            Activate(false);
        }
    }

    public void Activate(bool activate)
    {
        gameObject.SetActive(activate);
    }
}
