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
        Vector3[] playerPositions = { new Vector3(5, 0, 5), new Vector3(5, 0, -5), new Vector3(-5, 0, 5), new Vector3(-5, 0, -5) };
        playerInputManager = GetComponent<PlayerInputManager>();
        playerList = new GameObject[] { player1, player2, player3, player4 };
        for (int i = 0; i < 4; i++)
        {
            OnPlayerJoined();
            playerInputManager.JoinPlayer().transform.position = playerPositions[i];
        }
    }

    public void OnPlayerJoined()
    {
        if (playerInputManager != null)
            playerInputManager.playerPrefab = playerList[playerInputManager.playerCount];
    }
}
