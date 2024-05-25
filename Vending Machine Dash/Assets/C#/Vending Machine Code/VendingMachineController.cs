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

    public void OnPlayerSelectUp(InputAction.CallbackContext context){
        
    }

    public void OnPlayerSelectRight(InputAction.CallbackContext context){
        
    }

    public void OnPlayerSelectDown(InputAction.CallbackContext context){
        
    }

    public void OnPlayerSelectLeft(InputAction.CallbackContext context){
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
