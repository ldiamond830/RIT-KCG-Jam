using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemTypes
{
    EMPTY,
    MONEY,
    CAN_EMPTY,
    CAN_DRINK,
    MAX
};

public class Item : MonoBehaviour
{
    /// <summary>
    /// Item Type<br/>
    /// アイテムの種類
    /// </summary>
    public ItemTypes Type { get; protected set; }

    // Start is called before the first frame update
    void Start()
    {
        Type = ItemTypes.EMPTY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
