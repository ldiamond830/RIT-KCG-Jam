using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private float thirst;
    private const float maxThirst = 50;
    private int coins = 10;
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
        set {thirst = value;
        
            if(thirst > maxThirst)
            {
                thirst = maxThirst;
            }
        }
    }

    public int Coins{
        get {return coins;}
        set 
        { 
            coins = value;
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
                thirstGauge = canvas.transform.GetChild(1).GetComponent<Slider>(); ;
                CoinText = canvas.transform.GetChild(2).gameObject.GetComponent<Text>();
                break;
            case "Player 2(Clone)":
                thirstGauge = canvas.transform.GetChild(4).GetComponent<Slider>(); ;
                 CoinText = canvas.transform.GetChild(5).gameObject.GetComponent<Text>();
                break;
            case "Player 3(Clone)":
                thirstGauge = canvas.transform.GetChild(7).GetComponent<Slider>(); ;
                 CoinText = canvas.transform.GetChild(8).gameObject.GetComponent<Text>();
                break;
            case "Player 4(Clone)":
                thirstGauge = canvas.transform.GetChild(10).GetComponent<Slider>(); ;
                 CoinText = canvas.transform.GetChild(11).gameObject.GetComponent<Text>();
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

        CoinText.text = coins + " ¥";

        if (isDead)
        {
            gameObject.SetActive(false);
        }
    }

     public void DropMoney(int amt){
        Debug.Log(amt);   
        if(amt > coins){
            amt = coins;
        }
        coins -= amt;

        Vector3 random = new Vector3(Random.Range(-2, 2), 0, Random.Range(-2, 2));
        GameObject newCoin = Instantiate(coin);
        newCoin.transform.position = transform.position + random;
        var money = newCoin.GetComponent<Money>();
        money.moneyAmounts = amt;
        money.enabled = false;
        money.timeTillEnabled = 0.3f;
    }

}
