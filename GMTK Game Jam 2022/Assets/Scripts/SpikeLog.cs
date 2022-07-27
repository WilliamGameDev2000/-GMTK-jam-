using UnityEngine;

public class SpikeLog : MonoBehaviour
{
    [SerializeField] private float timeUntilDespawn;
    
    void Start()
    {
        Destroy(gameObject, timeUntilDespawn);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Dodger"))
        {
            Destroy(collision.gameObject);
        }
    }
}
