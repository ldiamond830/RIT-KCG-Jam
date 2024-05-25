using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private PlayerInputManager playerInputManager;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject player3;
    [SerializeField] private GameObject player4;
    public GameObject[] playerList;

    [SerializeField] private Camera cam;

    public int numberOfPlayers = 4;

    private void Awake()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        playerList = new GameObject[] { player1, player2, player3, player4 };
        Vector3[] playerPositions = { new Vector3(-5, .5f, 5), new Vector3(-5, .5f, -5), new Vector3(5, .5f, -5), new Vector3(5, .5f, 5) };
        playerInputManager = GetComponent<PlayerInputManager>();

        for (int i = 0; i < numberOfPlayers; i++)
        {
            OnPlayerJoined();
            playerList[i] = playerInputManager.JoinPlayer().transform.gameObject;
            playerList[i].transform.position = playerPositions[i];
        }
    }

    public void OnPlayerJoined()
    {
        if (playerInputManager != null)
            playerInputManager.playerPrefab = playerList[playerInputManager.playerCount];
    }
}
