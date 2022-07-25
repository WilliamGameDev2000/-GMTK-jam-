using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceBoulder : MonoBehaviour
{
    [SerializeField] private float movementForce = 2f;
    [SerializeField] private float LifeTimeInSecs = 5f;
    [SerializeField] private float hitForce = 10f;

    private void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(Vector3.back * movementForce, ForceMode.Impulse);
        Destroy(this.gameObject, LifeTimeInSecs);
    }

    private void FixedUpdate()
    {
        this.GetComponent<Rigidbody>().AddForce(Vector3.back * movementForce);
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Dodger"))
        {
            Debug.Log("Hit Dodger");
            GameObject dodger = collision.gameObject;
            //dodger.GetComponent<Rigidbody>().AddForce(Vector3.back * forceMultiplier, ForceMode.Impulse);
            dodger.GetComponent<CharacterController>().Move(Vector3.back * hitForce * Time.deltaTime);
        }
    }*/

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Dodger"))
        {
            Debug.Log("Hit Dodger");
            GameObject dodger = collision.gameObject;
            //dodger.GetComponent<Rigidbody>().AddForce(Vector3.back * forceMultiplier, ForceMode.Impulse);
            dodger.GetComponent<CharacterController>().Move(Vector3.back * hitForce * Time.deltaTime);
        }
    }
}
