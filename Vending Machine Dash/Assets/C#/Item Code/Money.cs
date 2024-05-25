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
    /// <summary>
    /// Amount of money<br/>
    /// ã‡äz
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

    private void OnCollisionEnter(Collision collision)
    {
        //If Money and Player collide
        //Ç‡ÇµÇ®ã‡Ç∆ÉvÉåÉCÉÑÅ[Ç™è’ìÀÇµÇΩÇÁ
        if (collision.collider.CompareTag("Player"))
        {
            //Get PlayerUI
            var playerUI = collision.gameObject.GetComponent<PlayerUI>();

            if (playerUI != null)
            {
                //Add Money in PlayerUI
                playerUI.Coins += MoneyAmounts;
            }

            //Delete this Money
            Destroy(this);
        }
    }
}
