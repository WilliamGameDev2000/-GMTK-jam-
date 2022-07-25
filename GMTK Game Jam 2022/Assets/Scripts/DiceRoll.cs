using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    public static GameObject Dice;
    static Rigidbody DiceRb;
    public static Vector3 DiceVel;

    // Start is called before the first frame update
    void Start()
    {
        Dice = gameObject;
        DiceRb = Dice.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        DiceVel = DiceRb.velocity;

        if(Input.GetKeyDown(KeyCode.A))
        {
            float dirX = Random.Range(50, 750);
            float dirY = Random.Range(50, 750);
            float dirZ = Random.Range(50, 750);
            transform.rotation = Quaternion.identity;
            transform.position = new Vector3(-3.43099999f, 7.07000017f, -11.4829998f);

            DiceRb.AddForce(transform.up * 550);
            DiceRb.AddTorque(dirX, dirY, dirZ);
        }

        if (DiceVel.x > 0f || DiceVel.y > 0f || DiceVel.z > 0)
        {
            DiceCheckZone.Instance.Activate(true);
        }
    }
}
