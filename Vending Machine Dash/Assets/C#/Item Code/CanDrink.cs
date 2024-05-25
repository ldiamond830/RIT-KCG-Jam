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

public class CanDrink : Item
{

    /// <summary>
    /// Amount of recovery of gauge.<br/>
    /// �Q�[�W�̉񕜗�
    /// </summary>
    public float RecoveryAmounts { get; set; }

    /// <summary>
    /// Price<br/>
    /// ���z
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
}
