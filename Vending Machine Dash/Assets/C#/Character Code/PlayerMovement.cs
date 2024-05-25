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
        if (playerInput.actions["Select Up"].triggered)
        {
            Debug.Log("ji");

        }
    }

    // Update is called once per frame
    void Update()
    {
        position = this.transform.position;
        Move();
    }

    private void Move()
    {
        Vector2 movement = playerInput.actions["Movement"].ReadValue<Vector2>();

        Debug.Log(movement);

        if (movement.x > 0 && Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            position.Set( position.x + 5f * Time.deltaTime, position.y, position.z);
        }

        if (movement.x < 0 && Mathf.Abs(movement.x) < Mathf.Abs(movement.y))
        {
            position.Set(position.x - 5f * Time.deltaTime, position.y, position.z);
        }

        if (movement.y > 0 && Mathf.Abs(movement.y) > Mathf.Abs(movement.x))
        {
            position.Set(position.x, position.y + 5f * Time.deltaTime, position.z);
        }

        if (movement.y < 0 && Mathf.Abs(movement.y) < Mathf.Abs(movement.x))
        {
            position.Set(position.x, position.y - 5f * Time.deltaTime, position.z);
        }
    }
}
