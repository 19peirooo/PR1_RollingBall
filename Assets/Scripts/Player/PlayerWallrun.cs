using System;
using UnityEngine;

public class PlayerWallrun : MonoBehaviour
{
    
    [SerializeField] private float wallCheckDistance = 0.7f;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private float jumpForce = 25f;
    [SerializeField] private Transform orientation;
    
    private RaycastHit leftHit, rightHit;
    private bool wallLeft, wallRight;
    private bool isWallRunning;
    private float wallJumpForce = 25f;
    
    private Rigidbody rb;
    
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        DetectarPared();
        HandleWallRun();
    }

    void FixedUpdate()
    {
        if (isWallRunning)
        {
            Wallrun();
        }
    }

    private void DetectarPared()
    {
        wallRight = Physics.Raycast(
            transform.position, orientation.right,
            out rightHit, wallCheckDistance, wallLayer);

        wallLeft = Physics.Raycast(
            transform.position, -orientation.right,
            out leftHit, wallCheckDistance, wallLayer);
    }

    private void HandleWallRun()
    {
        bool canWallRun = (wallLeft || wallRight);

        if (canWallRun)
        {
            if (!isWallRunning) StartWallrun();
            
            if (Input.GetKeyDown(KeyCode.Space)) WallJump();
        }
        else
        {
            StopWallRun();
        }
    }

    private void StartWallrun()
    {
        isWallRunning = true;
        rb.useGravity = false;
        
    }

    private void StopWallRun()
    {
        isWallRunning = false;
        rb.useGravity = true;
    }

    private void WallJump()
    {
        Vector3 wallNormal = wallRight ? rightHit.normal : leftHit.normal;
        Vector3 force = orientation.up * jumpForce + wallNormal * wallJumpForce;
        
        rb.AddForce(force, ForceMode.Impulse);

        StopWallRun();
        
    }
    
    private void Wallrun()
    {
        rb.useGravity = false;

        Vector3 wallNormal  = wallRight ? rightHit.normal : leftHit.normal;

        // Pegarse a la pared
        rb.AddForce(-wallNormal * 80f, ForceMode.Force);

    }
    
}
