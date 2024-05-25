using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private bool isHorizontal;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (isHorizontal)
            {
                other.transform.position = new Vector3(-other.transform.position.x, other.transform.position.y, other.transform.position.z);
            }
            else
            {
                other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, -other.transform.position.z);
            }
        }
    }
}
