using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(Item))]
#endif

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
    public int Price { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Type = ItemTypes.CAN_DRINK;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
