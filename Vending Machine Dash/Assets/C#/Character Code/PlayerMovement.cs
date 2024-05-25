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
    public float Speed = 5f; 

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

    public bool CanBuyDrink;
    public VendingMachineController vendingMachine;
    public bool PurchasedDrink;

    private PlayerUI UI;

    [SerializeField]
    private CanDrink canDrink;

    [SerializeField]
    private GameObject JPY5Drink;
    [SerializeField]
    private GameObject JPY10Drink;
    [SerializeField]
    private GameObject JPY15Drink;
    [SerializeField]
    private GameObject JPY20Drink;

    public void OnFire(InputAction.CallbackContext context)
    {
        if(projectile != null){
            GameObject newProjectile = Instantiate<GameObject>(projectile);

            Vector3 fwd = new Vector3(shootDirection.x, 0, shootDirection.y);
            newProjectile.transform.position = transform.position + fwd;
            newProjectile.GetComponentInChildren<Projectile>().Throw(fwd);

            projectile = null;
        }
        
    }


    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        UI = GetComponent<PlayerUI>();
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
            position.Set( position.x + Speed * Time.deltaTime, position.y, position.z);
        }

        else if (movement.x < -.5)
        {
            position.Set(position.x - Speed * Time.deltaTime, position.y, position.z);
        }

        else if (movement.y > 0.5)
        {
            position.Set(position.x, position.y, position.z + Speed * Time.deltaTime);
        }

        else if (movement.y < -.5)
        {
            position.Set(position.x, position.y, position.z - Speed * Time.deltaTime);
        }
    }

    public void Stun(float time){
        if(!stunned && iFrameTimer <= 0){
        stunned = true;
        stunTimer = time;
        iFrameTimer = 0.4f;
        }
    }

    public void PurchasePaperPackageDrink(InputAction.CallbackContext context)
    {
        Debug.Log("drink called");
        //Drink Can
        if (CanBuyDrink && CanCreator.Instance.cans[CanKinds.JPY5].Price <= UI.Coins && !vendingMachine.OnCoolDown)
        {
            vendingMachine.StartCoolDown();
            UI.Coins -= CanCreator.Instance.cans[CanKinds.JPY5].Price;
            UI.Thirst += CanCreator.Instance.cans[CanKinds.JPY5].RecoveryAmount;

        

            projectile = JPY5Drink;
        }
    }

}
