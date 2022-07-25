using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZone : MonoBehaviour
{
    Vector3 velocity;

    void FixedUpdate()
    {
        velocity = DiceRoll.Dice.GetComponent<Rigidbody>().velocity;
    }

    void OnTriggerEnter(Collider col)
    {
        if(velocity.x == 0 && velocity.y == 0 && velocity.z ==0)
        {

        }
    }
}
