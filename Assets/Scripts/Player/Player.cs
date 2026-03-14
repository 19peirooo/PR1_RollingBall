using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float jumpForce = 15;
    [SerializeField] private float baseMoveForce = 40;
    [SerializeField] private float sprintMultiplier = 2;
    [SerializeField] private Transform orientation;
    [SerializeField] private int lives = 5;
    
    private Rigidbody rb;
    private float hInput;
    private float vInput;
    private float moveForce;
    private Vector3 baseSize;
    private float gravMultiplier = 1f;
    
    //Variables de Estados Internos del Jugador
    private bool isSprinting = false;
    private bool isMini = false;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        baseSize = transform.localScale;
    }

    private void Start()
    {
        UIManager.Instance.LivesText.SetText(GameManager.Instance.Lives.ToString());
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
            rb.AddForce(Vector3.up * jumpForce * gravMultiplier, ForceMode.Impulse);
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Damage damage))
        {
            lives -= damage.ObtenerDamageAmount();
            transform.position = GameManager.Instance.SpawnPoint;
            UIManager.Instance.LivesText.SetText(lives.ToString());
        }
        else if (other.gameObject.TryGetComponent(out Portal portal))
        {
            portal.Enter(lives);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Life life))
        {
            lives += life.getLives();
            UIManager.Instance.LivesText.SetText(lives.ToString());
        }
        else if (other.gameObject.TryGetComponent(out LowGravZone lgz))
        {
            gravMultiplier = lgz.getGravMultiplier();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out LowGravZone lgz))
        {
            gravMultiplier = 1f;
        }
    }
}
