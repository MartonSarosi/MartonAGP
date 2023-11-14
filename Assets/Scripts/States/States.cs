using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class States : MonoBehaviour
{
    // State Stuff
    private CurrentPlayerState currentState;
    public readonly PersonState personState = new PersonState();
    public readonly GhostState ghostState = new GhostState();

    public GameObject playerObject, ghostObject;

    public Transform currentObject;
    

    // Player Stuff
    public CharacterController controller;

    public float defaultSpeed, ghostSpeed;
    public float currentSpeed { get; private set; }

    Vector3 velocity;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public float jumpHeight;

    //Ghost stuff
    

    //Wall-passing stuff
    public float wallPassSpeed = 20f;
    public float wallPassDuration = 2f;
    public KeyCode wallPassKey = KeyCode.R;

    public bool isWallPassing = false;
    public float wallPassTimer;

    public Vector2 moveDirection;
    void Start()
    {
        TransitionToState(personState);
        
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);

        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");

        Vector3 move = currentObject.right * moveDirection.x + currentObject.forward * moveDirection.y;

        controller.Move(move * currentSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
    }

    public void TransitionToState(CurrentPlayerState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public void SetSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }
}
