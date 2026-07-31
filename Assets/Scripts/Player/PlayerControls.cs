using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D playerRb; //Player Rigid body 2D
    private Vector2 movementInput; // Player Movement Function

    private Vector2 smoothMoveInput; //Makes player movement more smooth
    private Vector2 movementInputSmoothVelocity; // Tracks current speed of smooth movement

    //Player speed multiplier
    [SerializeField] private float playerMovementSpeed = 5f;
    [SerializeField] private float playerRotationSpeed = 5f;


    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();

        RotateInDirectionOfInput();
    }

    private void SetPlayerVelocity()
    {
        //Track Players current movementInput to allow for gradual
        //smoother stopping of the player when there is no input over time
        smoothMoveInput = Vector2.SmoothDamp(smoothMoveInput,
            movementInput,
            ref movementInputSmoothVelocity,
            0.1f);//When to trigger function 

        //Player Rigidbody2D will move based on the input and multiply by the float speed
        playerRb.linearVelocity = smoothMoveInput * playerMovementSpeed;
    }

    private void RotateInDirectionOfInput()
    { 
        //Check if player movement speed is not zero
        if (movementInput != Vector2.zero)
        {
            //Check target to rotate towards
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, smoothMoveInput);

            //Rotate towards target input
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, playerRotationSpeed * Time.deltaTime);

            playerRb.MoveRotation(rotation);
        }
    }

    //Move player based on NewInputSystem
    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
}
