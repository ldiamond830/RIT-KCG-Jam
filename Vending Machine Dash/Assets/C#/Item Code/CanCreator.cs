using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CanDrinkÇ‚CanEmptyÇê∂ê¨Ç∑ÇÈ
/// </summary>
public class CanCreator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Add the specified CanEmpty to the passed GameObject and returns CanEmpty.<br/>
    /// ìnÇ≥ÇÍÇΩGameObjectÇ…éwíËÇµÇΩCanEmptyÇí«â¡ÇµÇƒCanEmptyÇï‘Ç∑
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
                canDrink.Init(0.2f, CanKinds.JPY5);
                break;

            case CanKinds.JPY5:
                canDrink.Init(0.2f, CanKinds.JPY5);
                break;

            case CanKinds.JPY10:
                canDrink.Init(0.3f, CanKinds.JPY10);
                break;

            case CanKinds.JPY15:
                canDrink.Init(0.5f, CanKinds.JPY15);
                break;

            case CanKinds.JPY20:
                canDrink.Init(0.7f, CanKinds.JPY20);
                break;
        }

        return canDrink;
    }

    /// <summary>
    /// Add the specified CanDrink to the passed GameObject and returns CanDrink.<br/>
    /// ìnÇ≥ÇÍÇΩGameObjectÇ…éwíËÇµÇΩCanDrinkÇí«â¡ÇµÇƒCanDrinkÇï‘Ç∑
    /// </summary>
    /// <param name="_gameObject">GameObject to add CanDrink.</param>
    /// <param name="_canKinds">Kind of Can.(Price)</param>
    /// <returns></returns>
    public CanEmpty AddCanEmpty(GameObject _gameObject, CanKinds _canKinds)
    {
        var canEmpty = _gameObject.AddComponent<CanEmpty>();

        //throw speed
        //Fast
        float throwFast = 5f;

        //Slow
        float throwSlow = 2f;

        switch (_canKinds)
        {
            //exception
            default:
            case CanKinds.MAX:
            case CanKinds.EMPTY:
                canEmpty.Init(3, 15, throwSlow);
                break;

            case CanKinds.JPY5:
                canEmpty.Init(5, 15, throwSlow);
                break;

            case CanKinds.JPY10:
                canEmpty.Init(3, 15, throwFast);
                break;

            case CanKinds.JPY15:
                canEmpty.Init(3, 15, throwSlow);
                break;

            case CanKinds.JPY20:
                canEmpty.Init(3, -1, throwFast);
                break;
        }

        return canEmpty;
    }
}
