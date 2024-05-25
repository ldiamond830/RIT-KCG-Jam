using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayManager : MonoBehaviour
{
    PlayerInputManager manager;
    public GameObject[] Players;

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<PlayerInputManager>();
        Players = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            manager.JoinPlayer();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        //if (manager != null)
            //manager. playerPrefab = playerList[playerInputManger.playerCount];
    }

}
