using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VendingMachineController : MonoBehaviour
{
    [SerializeField]
    private GameObject UpDrink;
    [SerializeField]
    private GameObject RightDrink;
    [SerializeField]
    private GameObject DownDrink;
    [SerializeField]
    private GameObject LeftDrink;
    [SerializeField]
    private float coolDown;
    List<GameObject> playerList = new List<GameObject>();

    [SerializeField]
    private PlayerManager manager;

    private bool onCoolDown;
    private float coolDownTimer;

    public bool OnCoolDown
    {
        get { return onCoolDown; }
    }
/*
    public void OnPlayerSelectUp(InputAction.CallbackContext context){
        if(playerList.Count > 0)
        {
            var player = playerList[0].GetComponent<PlayerMovement>();
            player.Projectile = UpDrink;
        }
    }

    public void OnPlayerSelectRight(InputAction.CallbackContext context){
        if (playerList.Count > 0)
        {
            var player = playerList[0].GetComponent<PlayerMovement>();
            player.Projectile = RightDrink;
        }
    }

    public void OnPlayerSelectDown(InputAction.CallbackContext context){
        if (playerList.Count > 0)
        {
            var player = playerList[0].GetComponent<PlayerMovement>();
            player.Projectile = DownDrink;
        }
    }

    public void OnPlayerSelectLeft(InputAction.CallbackContext context){
        if (playerList.Count > 0)
        {
            var player = playerList[0].GetComponent<PlayerMovement>();
            player.Projectile = LeftDrink;
        }
    }
    */
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (onCoolDown)
        {
            coolDownTimer -= Time.deltaTime;

            if(coolDownTimer <= 0)
            {
                onCoolDown = false;
            }
        }
    }

   // 範囲内の全選手を保存
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
            player.CanBuyDrink = true;
            player.vendingMachine = this;
        }
    }

    //自販機のエリアから出たプレーヤーを取り除く
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player" && playerList.Contains(other.gameObject)){
            PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
            player.CanBuyDrink = false;
            player.vendingMachine = null;
        }
    }

    public void StartCoolDown()
    {
        onCoolDown = true;
        coolDownTimer = coolDown;
    }
}
