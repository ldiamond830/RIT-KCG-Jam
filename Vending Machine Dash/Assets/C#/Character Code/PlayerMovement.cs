using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] private Vector3 position;
    private Vector2 shootDirection;

    [SerializeField]
    private GameObject projectile = null;

    public GameObject Projectile{
        set {projectile = value;}
    }
    private bool stunned;
    private float stunTimer;
    private float iFrameTimer;
    
    [SerializeField]
    private GameObject coin;

   public void OnFire(InputValue context){
        if(projectile != null){
            GameObject newProjectile = Instantiate<GameObject>(projectile);

            Vector3 fwd = new Vector3(shootDirection.x, 0, shootDirection.y);
            newProjectile.transform.position = transform.position + fwd;
            newProjectile.GetComponentInChildren<Projectile>().Throw(fwd);

            //projectile = null;
        }
        
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

            if(iFrameTimer > 0){
                iFrameTimer -= Time.deltaTime;
            }
        }
        else{
            stunTimer -= Time.deltaTime;

            if(stunTimer <= 0){
                stunned = false;
            }
        }
    }

    private void Move()
    {
        Vector2 movement = playerInput.actions["Move"].ReadValue<Vector2>();

        if(movement != Vector2.zero){
            shootDirection = movement.normalized;
        }

        //Debug.Log(movement);

        if (movement.x > .5)
        {
            position.Set( position.x + 5f * Time.deltaTime, position.y, position.z);
        }

        else if (movement.x < -.5)
        {
            position.Set(position.x - 5f * Time.deltaTime, position.y, position.z);
        }

        else if (movement.y > 0.5)
        {
            position.Set(position.x, position.y, position.z + 5f * Time.deltaTime);
        }

        else if (movement.y < -.5)
        {
            position.Set(position.x, position.y, position.z - 5f * Time.deltaTime);
        }
    }

    public void Stun(float time){
        if(!stunned && iFrameTimer <= 0){
        stunned = true;
        stunTimer = time;
        iFrameTimer = 0.4f;
        }
    }

}
