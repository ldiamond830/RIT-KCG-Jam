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
    /// ”í’e‚µ‚Äs“®•s‰Â”\‚É‚È‚éŠÔ(•b)
    /// </summary>
    public float RestraintTime { get; private set; }

    /// <summary>
    /// Amount of money lost if attacked.<br/>
    /// ”í’e‚µ‚½‚ç—‚Æ‚·‚¨‹à‚Ì—Ê
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
