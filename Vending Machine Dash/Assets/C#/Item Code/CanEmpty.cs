using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(Item))]
#endif

public class CanEmpty : Item
{

    /// <summary>
    /// Time that a person is inactive due to being hit by a can.(seconds)<br/>
    /// 被弾して行動不可能になる時間(秒)
    /// </summary>
    public float RestraintTime { get; private set; }

    /// <summary>
    /// Amount of money lost if attacked.<br/>
    /// 被弾したら落とすお金の量
    /// </summary>
    public int LostMoney { get; private set; }



    // Start is called before the first frame update
    void Start()
    {
        Type = ItemTypes.CAN_EMPTY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
