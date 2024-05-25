using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(Item))]
#endif

//Memo 
//[GameObject].GetComponentInParent<Money>();

public class Money : Item
{

    public int moneyAmounts;
    /// <summary>
    /// Amount of money<br/>
    /// ���z
    /// </summary>
    public int MoneyAmounts { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Type = ItemTypes.MONEY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collision)
    {
        Debug.Log("dshfgadp");
        //If Money and Player collide
        //���������ƃv���C���[���Փ˂�����
        if (collision.transform.tag == "Player")
        {
            //Get PlayerUI
            var playerUI = collision.gameObject.GetComponent<PlayerUI>();

            if (playerUI != null)
            {
                //Add Money in PlayerUI
                playerUI.Coins += moneyAmounts;
            }

            //Delete this Money
            Destroy(gameObject);
        }
    }
}
