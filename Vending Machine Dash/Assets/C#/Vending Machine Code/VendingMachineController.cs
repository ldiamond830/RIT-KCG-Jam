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
    List<GameObject> playerList = new List<GameObject>();

    CanCreator creator;

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
    // Start is called before the first frame update
    void Start()
    {
        creator = this.gameObject.AddComponent<CanCreator>();

        creator.AddCanDrink(RightDrink, CanKinds.JPY5);
        creator.AddCanDrink(UpDrink, CanKinds.JPY10);
        creator.AddCanDrink(LeftDrink, CanKinds.JPY15);
        creator.AddCanDrink(DownDrink, CanKinds.JPY20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   // 範囲内の全選手を保存
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            playerList.Add(other.gameObject);
        }
    }

    //自販機のエリアから出たプレーヤーを取り除く
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player" && playerList.Contains(other.gameObject)){
            playerList.Remove(other.gameObject);
        }
    }
}
