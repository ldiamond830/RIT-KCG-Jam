using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position = this.transform.position;
        Move();
        this.transform.position = position;
    }

    private void Move()
    {
        Vector2 movement = playerInput.actions["Move"].ReadValue<Vector2>();

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
}
