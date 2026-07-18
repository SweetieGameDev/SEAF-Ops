using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D playerRb; //Player Rigid body 2D
    private Vector2 movementInput; // Player Movement Function

    private Vector2 smoothMoveInput; //Makes player movement more smooth
    private Vector2 movementInputSmoothVelocity; // Tracks current speed of smooth movement

    //Player speed multiplyer
    [SerializeField]private float playerSpeed = 5f; 


    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Track Players current movementInput to allow for gradual
        //smoother stopping of the player when there is no input over time
        smoothMoveInput = Vector2.SmoothDamp(smoothMoveInput, 
            movementInput, 
            ref movementInputSmoothVelocity,
            0.1f);//When to trigger funcion 

        //Player Rigidbody2D will move based on the input and multiply by the float speed
        playerRb.linearVelocity = smoothMoveInput * playerSpeed;
    }

    //Move player based on NewInputSystem
    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
}
