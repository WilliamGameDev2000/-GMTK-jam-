using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    [SerializeField] Rigidbody Dice;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            float dirX = Random.Range(0, 500);
            float dirY = Random.Range(0, 500);
            float dirZ = Random.Range(0, 500);
            transform.rotation = Quaternion.identity;

            Dice.AddForce(transform.up * 350);
            Dice.AddTorque(dirX, dirY, dirZ);
        }
    }
}
