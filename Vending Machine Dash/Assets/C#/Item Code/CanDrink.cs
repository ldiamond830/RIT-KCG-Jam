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

    /// <summary>
    /// Drink Can<br/>
    /// �ʂ�����
    /// </summary>
    /// <returns>
    /// Price of can drunk.<br/>
    /// ���񂾊ʂ̉��i
    /// </returns>
    public CanKinds Drink()
    {
        // Maybe there are other processes...
        //�����������瑼�ɂ����������邩������Ȃ��E�E�E
        return Price;
    }
}
