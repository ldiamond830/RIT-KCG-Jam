     using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Memo 
//[GameObject].GetComponentInParent<Money>();

public class Money : Item
{

    public int moneyAmounts;
    /// <summary>
    /// Amount of money
    /// </summary>
    public int MoneyAmounts { get; private set; }

    public float timeTillEnabled;

    //this will be set to false when a coin drops from a player for a short period
    //プレーヤーからコインが短時間ドロップした場合、これはfalseに設定されます。
    private bool enabled = true;

    // Start is called before the first frame update
    void Start()
    {
        Type = ItemTypes.MONEY;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeTillEnabled > 0){
            timeTillEnabled -= Time.deltaTime;

            if(timeTillEnabled <= 0){
                enabled = true;
            }
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        //If Money and Player collide
        if (collision.transform.tag == "Player")
        {
            //Get PlayerUI
            var playerUI = collision.gameObject.GetComponent<PlayerUI>();

            if (playerUI != null)
            {
                //Add Money in PlayerUI
                playerUI.Coins += moneyAmounts;
            }

            this.transform.GetComponent<AudioSource>().Play();

            //Delete this Money
            Destroy(gameObject);
        }
    }
}
