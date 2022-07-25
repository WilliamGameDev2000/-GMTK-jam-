using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    public static GameObject Dice;
    Rigidbody DiceRb;

    // Start is called before the first frame update
    void Start()
    {
        DiceRb = Dice.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            foreach(Transform side in Dice.transform)
            {
                side.GetComponent<SphereCollider>().enabled = true;
            }
            float dirX = Random.Range(0, 500);
            float dirY = Random.Range(0, 500);
            float dirZ = Random.Range(0, 500);
            transform.rotation = Quaternion.identity;

            DiceRb.AddForce(transform.up * 350);
            DiceRb.AddTorque(dirX, dirY, dirZ);
        }
    }
}
