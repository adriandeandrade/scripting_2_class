using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public enum MovementType { SMOOTH, ROUGH, MOUSE };
    public MovementType movementType;

    [SerializeField] private float moveSpeed;

    private Vector3 movement;

    private void Start()
    {

    }

    private void Update()
    {
        if (movementType == MovementType.SMOOTH)
        {
            SmoothMovement();
        }
        else if (movementType == MovementType.ROUGH)
        {
            RoughMovement();
        }
    }

    private void SmoothMovement()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        //movement = movement.normalized;
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    private void RoughMovement()
    {

    }

    private void MouseMovement()
    {

    }
}
