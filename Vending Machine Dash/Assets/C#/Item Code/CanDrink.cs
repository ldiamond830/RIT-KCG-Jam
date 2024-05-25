using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CanKinds
{
    EMPTY,
    JPY5,
    JPY10,
    JPY15,
    JPY20,
    MAX
}

//Memo 
//[GameObject].GetComponentInParent<CanDrink>();

public class CanDrink : Item
{

    /// <summary>
    /// Amount of recovery of gauge.<br/>
    /// ÉQÅ[ÉWÇÃâÒïúó 
    /// </summary>
    public float RecoveryAmounts { get; set; }

    /// <summary>
    /// Price<br/>
    /// ã‡äz
    /// </summary>
    public CanKinds Price { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Type = ItemTypes.CAN_DRINK;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    ///Set parameter
    public void Init(float _recoveryAmounts, CanKinds _price)
    {
        RecoveryAmounts = _recoveryAmounts;
        Price = _price;
    }

    /// <summary>
    /// Drink Can<br/>
    /// ä Çà˘Çﬁ
    /// </summary>
    /// <returns>
    /// Price of can drunk.<br/>
    /// à˘ÇÒÇæä ÇÃâøäi
    /// </returns>
    public CanKinds Drink(GameObject _player)
    {
        if (_player.CompareTag("Player"))
        {
            //Get PlayerUI
            var playerUI = _player.GetComponent<PlayerUI>();

            if (playerUI != null)
            {
                //Recovery thirst
                playerUI.Thirst += RecoveryAmounts;
            }

            switch (Price)
            {
                case CanKinds.MAX:
                default:
                case CanKinds.EMPTY:
                    break;

                case CanKinds.JPY5:
                    break;

                case CanKinds.JPY10:
                    break;

                case CanKinds.JPY15:
                    onDrink15jpy(playerUI);
                    break;

                case CanKinds.JPY20:
                    break;
            }
        }

        return Price;
    }

    //on drink 15JPY Can
    private void onDrink15jpy(PlayerUI _player)
    {
        //_player.[shield flag] = true;
    }
}
