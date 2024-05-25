using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;



/// <summary>
/// CanDrinkやCanEmptyを生成する
/// </summary>
public class CanCreator : MonoBehaviour
{
    [Serializable]
    private class CansParameter
    {
        public int Price;
        public float RecoveryAmounts;
        public float RestraintTime;
        public int LostMoney;
        public float ThrowingSpeed;
    }

    [SerializeField]
    private TextAsset
        json5jpy,
        json10jpy,
        json15jpy,
        json20jpy;

    private List<CansParameter> cans;

    // Start is called before the first frame update
    void Start()
    {
        cans = new List<CansParameter>();
        cans.Add(JsonUtility.FromJson<CansParameter>(json5jpy.text));
        cans.Add(JsonUtility.FromJson<CansParameter>(json10jpy.text));
        cans.Add(JsonUtility.FromJson<CansParameter>(json15jpy.text));
        cans.Add(JsonUtility.FromJson<CansParameter>(json20jpy.text));

        foreach (var c in cans)
        {
            Debug.Log(c.Price);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Add the specified CanEmpty to the passed GameObject and returns CanEmpty.<br/>
    /// 渡されたGameObjectに指定したCanEmptyを追加してCanEmptyを返す
    /// </summary>
    /// <param name="_gameObject">GameObject to add CanEmpty.</param>
    /// <param name="_canKinds">Kind of Can.(Price)</param>
    /// <returns></returns>
    public CanDrink AddCanDrink(GameObject _gameObject, CanKinds _canKinds)
    {
        var canDrink = _gameObject.AddComponent<CanDrink>();

        switch (_canKinds)
        {
            //exception
            default:
            case CanKinds.MAX:
            case CanKinds.EMPTY:
                canDrink.Init(cans[0].RecoveryAmounts, CanKinds.JPY5);
                break;

            case CanKinds.JPY5:
                canDrink.Init(cans[0].RecoveryAmounts, CanKinds.JPY5);
                break;

            case CanKinds.JPY10:
                canDrink.Init(cans[1].RecoveryAmounts, CanKinds.JPY10);
                break;

            case CanKinds.JPY15:
                canDrink.Init(cans[2].RecoveryAmounts, CanKinds.JPY15);
                break;

            case CanKinds.JPY20:
                canDrink.Init(cans[3].RecoveryAmounts, CanKinds.JPY20);
                break;
        }

        return canDrink;
    }

    /// <summary>
    /// Add the specified CanDrink to the passed GameObject and returns CanDrink.<br/>
    /// 渡されたGameObjectに指定したCanDrinkを追加してCanDrinkを返す
    /// </summary>
    /// <param name="_gameObject">GameObject to add CanDrink.</param>
    /// <param name="_canKinds">Kind of Can.(Price)</param>
    /// <returns></returns>
    public CanEmpty AddCanEmpty(GameObject _gameObject, CanKinds _canKinds)
    {
        var canEmpty = _gameObject.AddComponent<CanEmpty>();

        switch (_canKinds)
        {
            //exception
            default:
            case CanKinds.MAX:
            case CanKinds.EMPTY:
                canEmpty.Init(cans[0].RestraintTime, cans[0].LostMoney, cans[0].ThrowingSpeed);
                break;

            case CanKinds.JPY5:
                canEmpty.Init(cans[0].RestraintTime, cans[0].LostMoney, cans[0].ThrowingSpeed);
                break;

            case CanKinds.JPY10:
                canEmpty.Init(cans[1].RestraintTime, cans[1].LostMoney, cans[1].ThrowingSpeed);
                break;

            case CanKinds.JPY15:
                canEmpty.Init(cans[2].RestraintTime, cans[2].LostMoney, cans[2].ThrowingSpeed);
                break;

            case CanKinds.JPY20:
                canEmpty.Init(cans[3].RestraintTime, cans[3].LostMoney, cans[3].ThrowingSpeed);
                break;
        }

        return canEmpty;
    }
}
