using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float stunDuration;
    private Vector3 direction = new Vector2(1,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += direction * speed * Time.deltaTime;
    }

    public void Throw(Vector3 direction){
        this.direction = direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        Hit(other);
        Destroy(gameObject);
    }

    protected virtual void Hit(Collider other){
        if(other.tag == "Player"){
           //stun player and have them drop money 
           var UI = other.GetComponent<PlayerUI>();
           UI.DropMoney(15);
           UI.Coins -= 15;

            if(UI.Coins < 0){
                UI.Coins = 0;
            }

           var move = other.GetComponent<PlayerMovement>();
           move.Stun(stunDuration);
        }
    }
}
