using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(Item))]
#endif

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
    /// ゲージの回復量
    /// </summary>
    public float RecoveryAmounts { get; set; }

    /// <summary>
    /// Price<br/>
    /// 金額
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

    /// <summary>
    /// Drink Can<br/>
    /// 缶を飲む
    /// </summary>
    /// <returns>
    /// Price of can drunk.<br/>
    /// 飲んだ缶の価格
    /// </returns>
    public CanKinds Drink()
    {
        // Maybe there are other processes...
        //もしかしたら他にも処理をするかもしれない・・・
        return Price;
    }
}
