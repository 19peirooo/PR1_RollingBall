using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float jumpForce = 15;
    [SerializeField] private float baseMoveForce = 40;
    [SerializeField] private float sprintMultiplier = 2;
    [SerializeField] private float wallCheckDistance = 0.3f;
    [SerializeField] private LayerMask wallLayer;
    
    private Rigidbody rb;
    private float hInput;
    private float vInput;
    private float moveForce;
    
    //Variables de Estados Internos del Jugador
    private bool isSprinting = false;
    private bool isWallRunning = false;
    private bool isOnValidWall = false;
    
    //Cosas de WallRun
    private Collider lastWall;
    private RaycastHit wallHit;
    private Vector3 wallNormal;
    private float wallStickForce = 10f;

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, transform.localScale.y);
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
        isSprinting = Input.GetKey(KeyCode.LeftShift);
        moveForce = isSprinting ? baseMoveForce * sprintMultiplier : baseMoveForce;
        if (isGrounded()) lastWall = null;
        
        
        DetectWall();
        HandleWallRun();
        Jump();
        
    }

    void FixedUpdate()
    {

        if (!isWallRunning)
        {
            Vector3 movement = new Vector3(hInput, 0, vInput).normalized;
            rb.AddForce(movement * moveForce, ForceMode.Force);
        }
        else
        {

            Vector3 wallForward = Vector3.Cross(wallNormal, Vector3.up);

            // Orientar según hacia donde mira el jugador
            if (Vector3.Dot(wallForward, transform.forward) < 0)
                wallForward = -wallForward;

            rb.AddForce(wallForward * moveForce * vInput, ForceMode.Force); //Fuerza de Movimiento en el wallrun 
            rb.AddForce(-wallNormal * wallStickForce, ForceMode.Force); //Hace que te "pegues" a la pared
        }
        
    }

    private void DetectWall()
    {
        bool wallRight = Physics.Raycast(transform.position, 
                                        transform.right, 
                                        out wallHit, //Cosa con la que choca el rayo
                                        wallCheckDistance,
                                        wallLayer);
        
        bool wallLeft = Physics.Raycast(transform.position, 
                                        -transform.right,
                                        out RaycastHit leftHit, 
                                        wallCheckDistance,
                                        wallLayer);
        
        if (!wallRight && wallLeft) wallHit = leftHit;
        
        bool validTag = (wallRight || wallLeft) && wallHit.collider.CompareTag("WallRunnable");
        
        isOnValidWall = validTag && wallHit.collider != lastWall;
        
        if (isOnValidWall) wallNormal = wallHit.normal;
        
    }
    
    private void Jump()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        
        if (isGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        } else if (isOnValidWall)
        {
            WallJump();
        }
    }

    private void HandleWallRun()
    {
        bool canWallRun = isOnValidWall && !isGrounded();
        
        if (canWallRun && !isWallRunning)
        {
            WallRun();
        }

        if (!canWallRun && isWallRunning)
        {
            StopWallRun();
        }
    }

    private void WallRun()
    {
        isWallRunning = true;
        rb.useGravity = false;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
    }

    private void StopWallRun()
    {
        isWallRunning = false;
        rb.useGravity = true;
    }

    private void WallJump()
    {
        lastWall = wallHit.collider;
        
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        Vector3 jumpDir = wallNormal * jumpForce + Vector3.up * jumpForce;
        rb.AddForce(jumpDir, ForceMode.Impulse);
        
        StopWallRun();
    }
    
}
