using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private float thirst;
    private const float maxThirst = 100;
    private int coins;
    private bool isDead;

    [SerializeField]
    private Slider thirstGauge;
    [SerializeField]
    private Text CoinText;

    public float Thirst{
        get{return thirst;}
        set {thirst = value;}
    }

    public int Coins{
        get {return coins;}
        set 
        { 
            coins = value;
            //CoinText.text = coins + " ¥";
        }
    }

    public bool IsDead{
        get{return isDead;}
    }

    // Start is called before the first frame update
    void Start()
    {
        thirst = maxThirst;
    }

    // Update is called once per frame
    void Update()
    {
        //thirstGauge.value = thirst/maxThirst;
        thirst -= Time.deltaTime;

        if(thirst <= 0){
            isDead = true;
        }
    }
}
