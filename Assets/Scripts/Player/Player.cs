using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float jumpForce = 15;
    [SerializeField] private float baseMoveForce = 40;
    [SerializeField] private float sprintMultiplier = 2;
    [SerializeField] private Transform orientation;
    
    private Rigidbody rb;
    private float hInput;
    private float vInput;
    private float moveForce;
    private Vector3 baseSize;
    
    //Variables de Estados Internos del Jugador
    private bool isSprinting = false;
    private bool isMini = false;
    
    private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            baseSize = transform.localScale;
        }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, transform.localScale.y);
    }
    
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
        isSprinting = Input.GetKey(KeyCode.LeftShift);
        isMini =  Input.GetKey(KeyCode.LeftControl);
        moveForce = isSprinting ? baseMoveForce * sprintMultiplier : baseMoveForce;
        transform.localScale = isMini ? baseSize/2 : baseSize;
        orientation.position = transform.position;
        Jump();
        
    }

    void FixedUpdate()
    {

        Vector3 movement = new Vector3(hInput, 0, vInput).normalized;
        rb.AddForce(movement * moveForce, ForceMode.Force);
        
    }
    
    private void Jump()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        
        if (isGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
