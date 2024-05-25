using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTiling : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objects;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (var item in objects)
        {
            item.GetComponent<Renderer>().
                material.mainTextureScale
                = new Vector2(item.transform.localScale.x, item.transform.localScale.z);
        }
    }
}
