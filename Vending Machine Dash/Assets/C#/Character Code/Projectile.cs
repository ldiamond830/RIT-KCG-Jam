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

    [SerializeField]
    private int dropAmount;

    private PlayerMovement owner;
    public PlayerMovement Owner{
        set{owner = value;}
    }
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
        var move = other.GetComponent<PlayerMovement>();

        if (move != owner)
        {
            Debug.Log("Hit: " + other.name);
            Hit(other, move);

        }
        if (other.tag != "Coin" && other.tag != "Ground")
        {
            Destroy(gameObject);
        }
    }

    protected virtual void Hit(Collider other, PlayerMovement move){
        if(other.tag == "Player" && !move.Barrier){

            //stun player and have them drop money 
           var UI = other.GetComponent<PlayerUI>();
           

            UI.DropMoney(dropAmount);

           
           move.Stun(stunDuration);
           
        }
    }
}
