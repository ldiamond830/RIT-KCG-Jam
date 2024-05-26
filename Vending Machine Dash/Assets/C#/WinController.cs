using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinController : MonoBehaviour
{
    [SerializeField]
    private Text winText;
    // Start is called before the first frame update
    void Start()
    {
        winText.text = PlayerPrefs.GetString("winner") + " WINS";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
