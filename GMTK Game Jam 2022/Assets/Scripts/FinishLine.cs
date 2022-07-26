using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private int playersFinished;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dodger") && GameManager.Instance.gameOver == false)
        {
            DiceDodgerController dodger = other.GetComponent<DiceDodgerController>();

            if (GameManager.Instance.gamemode == GameManager.GameMode.COOPERATIVE && !dodger.Finished)
            {
                playersFinished++;
                if (playersFinished == PlayerSpawner.Instance.numberOfPlayers - 1)
                {
                    //Debug.Log("Dodgers Win!!!");
                    GameManager.Instance.GameOver("Dodgers Win!!!");
                }
                dodger.Finished = true;
            }
            else if (GameManager.Instance.gamemode == GameManager.GameMode.COMPETITIVE)
            {
                //Debug.Log("Dodger " + other.GetComponent<DiceDodgerController>().dodgerID + " wins!!!");
                GameManager.Instance.GameOver("Dodger " + other.GetComponent<DiceDodgerController>().dodgerID + " wins!!!");
            }
        }
    }
}
