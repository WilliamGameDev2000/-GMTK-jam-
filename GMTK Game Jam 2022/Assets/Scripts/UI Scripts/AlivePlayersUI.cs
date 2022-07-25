using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlivePlayersUI : MonoBehaviour
{
    [SerializeField] private GameObject player1Cross;
    [SerializeField] private GameObject player2Cross;
    [SerializeField] private GameObject player3Cross;

    void Start()
    {
        player1Cross.SetActive(false);
        player2Cross.SetActive(false);
        player3Cross.SetActive(false);
    }

    void Update()
    {
        /*
         * if player die
         * {
         *  activate correct cross dead player
         * }
         */
    }
}
