using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinController : MonoBehaviour
{
    [SerializeField]
    private Image p1;
    [SerializeField]
    private Image p2;
    [SerializeField]
    private Image p3;
    [SerializeField]
    private Image p4;
    // Start is called before the first frame update
    void Start()
    {
        switch (PlayerPrefs.GetInt("Winner"))
        {
            case 0:
                p1.gameObject.SetActive(true);
                break;
            case 1:
                p2.gameObject.SetActive(true);
                break;
            case 3:
                p3.gameObject.SetActive(true);
                break;
            case 4:
                p4.gameObject.SetActive(true);
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
