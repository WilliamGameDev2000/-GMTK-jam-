using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceBoulder : MonoBehaviour
{
    [SerializeField] private float forceMultiplier = 2f;
    [SerializeField] private float LifeTimeInSecs = 5f;

    private void Start()
    {
        this.GetComponent<Rigidbody>().AddForce(Vector3.back * forceMultiplier, ForceMode.Impulse);
        Destroy(this.gameObject, LifeTimeInSecs);
    }

    private void FixedUpdate()
    {
        this.GetComponent<Rigidbody>().AddForce(Vector3.back * forceMultiplier);
    }
}
