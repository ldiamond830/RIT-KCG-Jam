using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuControl : MonoBehaviour
{
    [SerializeField]
    private Image Credits;
    [SerializeField]
    GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleCredits()
    {
        Credits.gameObject.SetActive(!Credits.gameObject.active);
        button.SetActive(!Credits.gameObject.active);
    }
}
