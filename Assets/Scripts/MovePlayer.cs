using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    //Movement speed
    private float moveSpeed;
    public float walkSpeed;
    public float runSpeed;
    
    public Transform orientation;
    // Jumping
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;

    // Crouching
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;

    // Ground detection
    public float groundDrag;
    public float playerHeight;
    public LayerMask whatIsGround;
    bool isOnGround;

    //Slope Handling
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    float horizontalInput;
    float verticalInput;

    private GameManager gameManagerScript;

    Vector3 moveDirection;

    Rigidbody rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        gameManagerScript = GameObject.Find("Game manager").GetComponent<GameManager>();

        startYScale = transform.localScale.y;
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    public MovementState state;
   public enum MovementState
    {
        walking,
        sprinting,
        crouching,
        air
    }
    
    private void MyInput() 
    {
        if (gameManagerScript.isGameActive == true)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

            if (Input.GetKey(jumpKey) && readyToJump && isOnGround)
            {
                Jump();

                readyToJump = false;

                Invoke(nameof(ResetJump), jumpCooldown);
            }

            if (Input.GetKeyDown(crouchKey))
            {
                transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
                rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
            }

            if (Input.GetKeyUp(crouchKey))
            {
                transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
            }
        }

        
    }
    // Update is called once per frame
    void Update()
    {
        if(gameManagerScript.isGameActive == true)
        {
            // ground check
            isOnGround = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
            MyInput();
            SpeedControl();
            StateHandler();

            if (isOnGround)
            {
                rb.linearDamping = groundDrag;
            }
            else
            {
                rb.linearDamping = 0;
            }
        }
       
    }


    private void StateHandler()
    {
        if(gameManagerScript.isGameActive == true)
        {
            // Mode - sneaking man
            if (Input.GetKey(crouchKey))
            {
                state = MovementState.crouching;
                moveSpeed = crouchSpeed;
            }
            // Mode - running man
            if (isOnGround && Input.GetKey(sprintKey))
            {
                state = MovementState.sprinting;
                moveSpeed = runSpeed;
            }

            // Mode - walking man
            else if (isOnGround)
            {
                state = MovementState.walking;
                moveSpeed = walkSpeed;
            }

            // Mode - Jumping man
            else
            {
                state = MovementState.air;
            }
        }
        
    }

    private void PlayerMovement() 
    { 
        if (gameManagerScript.isGameActive == true)
        {
            // calculate movement direction
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

            // on slope
            if (OnSlope() && !exitingSlope)
            {
                rb.AddForce(GetSlopeMoveDirection() * moveSpeed * 20f, ForceMode.Force);

                if (rb.angularVelocity.y > 0)
                {
                    rb.AddForce(Vector3.down * 80f, ForceMode.Force);
                }
            }

            // on ground
            if (isOnGround)
            {
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
            }

            // in air
            else if (!isOnGround)
            {
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
            }

            // turn gravity off while on slope
            rb.useGravity = !OnSlope();
        }
      
    }

    private void SpeedControl() 
    { 
        if (gameManagerScript.isGameActive == true)
        {
            // limiting speed on slope
            if (OnSlope() && !exitingSlope)
            {
                if (rb.angularVelocity.magnitude > moveSpeed)
                {
                    rb.angularVelocity = rb.angularVelocity.normalized * moveSpeed;
                }
            }

            // limiting speed on ground or in air
            else
            {
                Vector3 flatVel = new Vector3(rb.angularVelocity.x, 0f, rb.angularVelocity.z);

                // limit velocity if necessary
                if (flatVel.magnitude > moveSpeed)
                {
                    Vector3 limitedVel = flatVel.normalized * moveSpeed;
                    rb.angularVelocity = new Vector3(limitedVel.x, rb.angularVelocity.y, limitedVel.z);
                }
            }
        }
                
    }

    private void Jump()
    {
        if (gameManagerScript.isGameActive == true)
        {
            exitingSlope = true;

            // reset y velocity
            rb.angularVelocity = new Vector3(rb.angularVelocity.x, 0f, rb.angularVelocity.z);

            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
        
    }

    private void ResetJump ()
    {
        if (gameManagerScript.isGameActive == true)
        {
            readyToJump = true;

            exitingSlope = false;
        }
        
    }

    private bool OnSlope() 
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f)) 
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }
        return false;
    }
    private Vector3 GetSlopeMoveDirection() 
    { 
       return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }
}
