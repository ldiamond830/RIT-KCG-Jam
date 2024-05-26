using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
        Vector3[] playerPositions = { new Vector3(-8, 1, 5), new Vector3(8, 1, 5), new Vector3(-8, 1, -5), new Vector3(8, 1, -5) };
        playerInputManager = GetComponent<PlayerInputManager>();

        for (int i = 0; i < numberOfPlayers; i++)
        {
            OnPlayerJoined();
            playerList[i] = playerInputManager.JoinPlayer().transform.gameObject;
            Debug.Log(playerList[i].name);
            playerList[i].transform.position = playerPositions[i];
        }
    }

    public void OnPlayerJoined()
    {
        if (playerInputManager != null)
            playerInputManager.playerPrefab = playerList[playerInputManager.playerCount];
    }

    public void Update()
    {
        int aliveCount = numberOfPlayers;
        for (int i = 0; i < numberOfPlayers; i++)
        {
            if (playerList[i].GetComponent<PlayerUI>().IsDead)
            {
                aliveCount--;
            }
        }

        if(aliveCount == 1)
        {
            for(int i = 0; i < numberOfPlayers; i++)
            {
                if (!playerList[i].GetComponent<PlayerUI>().IsDead)
                {
                    PlayerPrefs.SetInt("Winner", i);
                    SceneManager.LoadScene("WinScene");
                }
            }
        }
    }
}
