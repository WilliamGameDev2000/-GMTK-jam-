using UnityEngine;

public class Ocean : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dodger"))
        {
            Destroy(other.gameObject);
        }
    }
}
