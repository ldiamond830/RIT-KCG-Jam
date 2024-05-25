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

    [SerializeField]
    private GameObject coin;
    [SerializeField]
    private Canvas canvas;

    public float Thirst{
        get{return thirst;}
        set {thirst = value;}
    }

    public int Coins{
        get {return coins;}
        set 
        { 
            coins = value;
            CoinText.text = coins + " ¥";
        }
    }

    public bool IsDead{
        get{return isDead;}
    }

    // Start is called before the first frame update
    void Start()
    {
        thirst = maxThirst;
        canvas = FindAnyObjectByType<Canvas>();

        switch (this.transform.name)
        {
            case "Player 1(Clone)":
                thirstGauge = canvas.transform.GetChild(0).GetChild(0).GetComponent<Slider>(); ;
                coin = canvas.transform.GetChild(0).GetChild(1).gameObject;
                break;
            case "Player 2(Clone)":
                thirstGauge = canvas.transform.GetChild(1).GetChild(0).GetComponent<Slider>(); ;
                coin = canvas.transform.GetChild(1).GetChild(1).gameObject;
                break;
            case "Player 3(Clone)":
                thirstGauge = canvas.transform.GetChild(2).GetChild(0).GetComponent<Slider>(); ;
                coin = canvas.transform.GetChild(2).GetChild(1).gameObject;
                break;
            case "Player 4(Clone)":
                thirstGauge = canvas.transform.GetChild(3).GetChild(0).GetComponent<Slider>(); ;
                coin = canvas.transform.GetChild(3).GetChild(1).gameObject;
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        thirstGauge.value = thirst/maxThirst;
        thirst -= Time.deltaTime;

        if(thirst <= 0){
            isDead = true;
        }
    }

     public void DropMoney(int amt){
        if(amt > coins){
            amt = coins;
        }
        Vector3 random = new Vector3(Random.Range(-2, 2), 0, Random.Range(-2, 2));
        //Duplicate coins from Player to a random range.
        GameObject newCoin = Instantiate(coin,
            this.transform.position + random,
            this.transform.rotation);
        //Set newCoin.moneyAmount to amt
        newCoin.GetComponent<Money>().moneyAmounts = amt;
    }

}
