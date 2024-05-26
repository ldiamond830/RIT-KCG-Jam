using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Start Menu" && Input.anyKeyDown)
        {
            ChangeScene();
        }
           
    }

    public void ChangeScene()
    {
        if(SceneManager.GetActiveScene().name == "Start Menu")
        {
            SceneManager.LoadScene("GameField1");
        }
    }
}
