using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] private Vector3 position;
    private Vector2 direction;

    [SerializeField]
    private GameObject projectile;

    private bool stunned;

   public void OnFire(InputValue context){
        GameObject newProjectile = Instantiate<GameObject>(projectile);
        Vector3 fwd = new Vector3(direction.x, 0, direction.y);
        newProjectile.transform.position = transform.position + fwd;
        newProjectile.GetComponentInChildren<Projectile>().Throw(fwd);
    }


    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!stunned){
            position = this.transform.position;
            Move();
            this.transform.position = position; 
        }
        else{
            
        }
    }

    private void Move()
    {
        direction = playerInput.actions["Move"].ReadValue<Vector2>();

        //Debug.Log(movement);

        if (direction.x > .5)
        {
            position.Set( position.x + 5f * Time.deltaTime, position.y, position.z);
        }

        else if (direction.x < -.5)
        {
            position.Set(position.x - 5f * Time.deltaTime, position.y, position.z);
        }

        else if (direction.y > 0.5)
        {
            position.Set(position.x, position.y, position.z + 5f * Time.deltaTime);
        }

        else if (direction.y < -.5)
        {
            position.Set(position.x, position.y, position.z - 5f * Time.deltaTime);
        }
    }

    public void Stun(float time){

    }
}
