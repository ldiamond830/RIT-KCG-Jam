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
            playerList[i] = playerInputManager.JoinPlayer().transform.gameObject;
            playerList[i].transform.position = playerPositions[i];
        }
    }

    private void Update()
    {
        for (int i = 0; i < 4; i++) {
            Vector3 playerPos = cam.WorldToScreenPoint(playerList[i].transform.position);
            if (playerPos.x <= 0)
            {
                this.transform.position = new Vector3(this.transform.position.x - 15.925f, this.transform.position.y, this.transform.position.z);
            }
            else if (playerPos.x >= Screen.width)
            {
                this.transform.position = new Vector3(this.transform.position.x + 15.925f, this.transform.position.y, this.transform.position.z);
            }
            if (playerPos.y <= 0)
            {
                Debug.Log(playerPos);
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 8.96f, this.transform.position.z);
            }
            else if (playerPos.y >= Screen.height)
            {
                Debug.Log(playerPos);
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 8.96f, this.transform.position.z);
            }
        }
    }

    public void OnPlayerJoined()
    {
        if (playerInputManager != null)
            playerInputManager.playerPrefab = playerList[playerInputManager.playerCount];
    }
}
