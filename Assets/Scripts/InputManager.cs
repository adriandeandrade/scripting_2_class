using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public enum MovementType { SMOOTH, ROUGH, MOUSE, PHYSICS, MULTI, CUSTOM };
    public MovementType movementType;

    [SerializeField] private float moveSpeed;

    private Vector3 movement;

    [SerializeField] private Rigidbody rBody;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(0);
        }

        if (movementType == MovementType.SMOOTH)
        {
            SmoothMovement();
        }
        else if (movementType == MovementType.ROUGH)
        {
            RoughMovement();
        }
        else if (movementType == MovementType.MOUSE)
        {
            MouseMovement();
        }
        else if (movementType == MovementType.MULTI)
        {
            MultiInputMovement();
        }
        else if (movementType == MovementType.CUSTOM)
        {
            CustomMovement();
        }
    }

    private void FixedUpdate()
    {
        if (movementType == MovementType.PHYSICS)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PhysicsJump();
            }
        }
    }

    private void SmoothMovement()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        float movementMag = Mathf.Clamp(movement.magnitude, 0f, 1f);
        Vector3 movementNorm = movement.normalized;
        Vector3 desiredMovement = movementNorm * movementMag;
        transform.Translate(desiredMovement * moveSpeed * Time.deltaTime);
    }

    private void RoughMovement()
    {
        movement = new Vector3(Input.GetAxisRaw("HorizontalAD"), 0f, Input.GetAxisRaw("VerticalWS"));
        float movementMag = Mathf.Clamp(movement.magnitude, 0f, 1f);
        Vector3 movementNorm = movement.normalized;
        Vector3 desiredMovement = movementNorm * movementMag;
        transform.Translate(desiredMovement * moveSpeed * Time.deltaTime);
    }

    private void MouseMovement()
    {
        movement = new Vector3(Input.GetAxis("Mouse X"), 0f, Input.GetAxis("Mouse Y"));
        float movementMag = Mathf.Clamp(movement.magnitude, 0f, 1f);
        Vector3 movementNorm = movement.normalized;
        Vector3 desiredMovement = movementNorm * movementMag;
        transform.Translate(desiredMovement * moveSpeed * Time.deltaTime);
    }

    private void PhysicsJump()
    {
        rBody.AddForce(Vector3.up * moveSpeed, ForceMode.Impulse);
    }

    private void MultiInputMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }

            if (Input.GetKeyUp(KeyCode.B))
            {
                transform.position += -Vector3.right * moveSpeed * Time.deltaTime;
            }
        }
    }

    private void CustomMovement()
    {
        movement = new Vector3(Input.GetAxis("HorizontalNumpad"), 0f, Input.GetAxis("VerticalNumpad"));
        float movementMag = Mathf.Clamp(movement.magnitude, 0f, 1f);
        Vector3 movementNorm = movement.normalized;
        Vector3 desiredMovement = movementNorm * movementMag;
        transform.Translate(desiredMovement * moveSpeed * Time.deltaTime);
    }
}
