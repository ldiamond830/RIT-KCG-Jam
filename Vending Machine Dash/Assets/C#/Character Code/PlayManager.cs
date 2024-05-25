using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayManager : MonoBehaviour
{
    private PlayerInputManager playerInputManager;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject player3;
    [SerializeField] private GameObject player4;
    public GameObject[] playerList;



    private void OnEnable()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        playerList = new GameObject[] { player1, player2, player3, player4 };

    }

    private void Awake()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        playerList = new GameObject[] { player1, player2, player3, player4 };
        for (int i = 0; i < 4; i++)
        {
            OnPlayerJoined();
            playerInputManager.JoinPlayer();
        }

        player1.transform.position = new Vector3(5, 0, 5);
        player2.transform.position = new Vector3(5, 0, -5);
        player3.transform.position = new Vector3(-5, 0, 5);
        player4.transform.position = new Vector3(-5, 0, -5);
    }

    public void OnPlayerJoined()
    {
        if (playerInputManager != null)
            playerInputManager.playerPrefab = playerList[playerInputManager.playerCount];
    }
}
