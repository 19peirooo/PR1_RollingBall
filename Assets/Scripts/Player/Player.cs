using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    
    [SerializeField] private float jumpForce = 15;
    [SerializeField] private float baseMoveForce = 40;
    [SerializeField] private float baseWallMoveForce = 80;
    [SerializeField] private float sprintMultiplier = 2;
    [SerializeField] private float wallCheckDistance = 0.3f;
    [SerializeField] private LayerMask wallLayer;
    
    private Rigidbody rb;
    private float hInput;
    private float vInput;
    private float moveForce;
    private float wallMoveForce;
    private Vector3 baseSize;
    
    //Variables de Estados Internos del Jugador
    private bool isSprinting = false;
    private bool isMini = false;
    private bool isWallRunning = false;
    private bool isOnValidWall = false;
    
    //Cosas de WallRun
    private Collider lastWall;
    private RaycastHit wallHit;
    private Vector3 wallNormal;
    private float wallStickForce = 2f;
    

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, transform.localScale.y);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        baseSize = transform.localScale;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
        isSprinting = Input.GetKey(KeyCode.LeftShift);
        isMini =  Input.GetKey(KeyCode.LeftControl);
        moveForce = isSprinting ? baseMoveForce * sprintMultiplier : baseMoveForce;
        wallMoveForce = isSprinting ? baseWallMoveForce * sprintMultiplier : baseWallMoveForce;
        if (isGrounded()) lastWall = null;
        transform.localScale = isMini ? baseSize/2 : baseSize;
        
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
            
            Vector3 alongWall = Vector3.Cross(wallNormal, Vector3.up).normalized;
            Vector3 movement = alongWall * vInput + transform.right * hInput;
            rb.AddForce(movement * wallMoveForce, ForceMode.Force);
            rb.AddForce(-wallNormal * wallStickForce, ForceMode.Force);
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
        
        bool validTag = (wallRight || wallLeft);
        
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
