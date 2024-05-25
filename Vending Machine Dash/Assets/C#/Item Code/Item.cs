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

//Memo 
//[GameObject].GetComponentInParent<Item>();

public class Item : MonoBehaviour
{
    /// <summary>
    /// Item Type
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
