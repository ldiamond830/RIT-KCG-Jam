using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float stunDuration;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        gameObject.transform.position += direction * speed * Time.deltaTime;
    }

    public void Throw(Vector3 direction){
        this.direction = direction;
=======
        
    }

    public void Throw(Vector3 direction){
        
>>>>>>> Stashed changes
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
<<<<<<< Updated upstream
           //stun player and have them drop money 
           Debug.Log("player hit");
=======
           
>>>>>>> Stashed changes
        }

        Destroy(this);
    }
}
