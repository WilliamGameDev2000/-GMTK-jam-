using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceBoulder : MonoBehaviour
{
    [SerializeField] private float movementForce = 2f;
    [SerializeField] private float LifeTimeInSecs = 5f;
    [SerializeField] private float hitForce = 10f;
    public static Vector3 DiceVel;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rb.AddForce(Vector3.back * movementForce, ForceMode.Impulse);
        Destroy(gameObject, LifeTimeInSecs);
    }

    private void FixedUpdate()
    {
        _rb.AddForce(Vector3.back * movementForce);
    }

    private void Update()
    {
        DiceVel = _rb.velocity;
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
