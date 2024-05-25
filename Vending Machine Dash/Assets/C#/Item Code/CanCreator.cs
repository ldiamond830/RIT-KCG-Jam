using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;



/// <summary>
/// Generate CanDrink and CanEmpty.
/// </summary>
public class CanCreator : MonoBehaviour
{
    private static CanCreator instance;
    public static CanCreator Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new CanCreator();
            }

            return instance;
        }
    }

    [Serializable]
    public class CansParameter
    {
        public int Price;
        public float RecoveryAmounts;
        public float RestraintTime;
        public int LostMoney;
        public float ThrowingSpeed;
    }

    public struct CanConfig
    {
        public int Price;
        public float RecoveryAmount;

    }

    [SerializeField]
    private TextAsset
        json5jpy,
        json10jpy,
        json15jpy,
        json20jpy;

    public Dictionary<CanKinds, CanConfig> cans;

    private CanCreator()
    {
        cans = new Dictionary<CanKinds, CanConfig>();
        /*
        cans.Add(CanKinds.JPY5, JsonUtility.FromJson<CansParameter>(json5jpy.text));
        cans.Add(CanKinds.JPY10, JsonUtility.FromJson<CansParameter>(json10jpy.text));
        cans.Add(CanKinds.JPY15, JsonUtility.FromJson<CansParameter>(json15jpy.text));
        cans.Add(CanKinds.JPY20, JsonUtility.FromJson<CansParameter>(json20jpy.text));
        */
        cans.Add(CanKinds.JPY5, new CanConfig {Price= 5, RecoveryAmount = 20.0f});
        cans.Add(CanKinds.JPY10, new CanConfig { Price = 10, RecoveryAmount = 30.0f });
        cans.Add(CanKinds.JPY15, new CanConfig { Price = 15, RecoveryAmount = 50.0f });
        cans.Add(CanKinds.JPY20, new CanConfig { Price = 20, RecoveryAmount = 70.0f });
    }

    // Start is called before the first frame update
    void Start()
    {
        

        ////Debug
        //foreach (var c in cans)
        //{
        //    Debug.Log(c.Price);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Add the specified CanEmpty to the passed GameObject and returns CanEmpty.
    /// </summary>
    /// <param name="_gameObject">GameObject to add CanEmpty.</param>
    /// <param name="_canKinds">Kind of Can.(Price)</param>
    /// <returns></returns>
    /// 
    /*
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
    /// Add the specified CanDrink to the passed GameObject and returns CanDrink.
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
    */
}
