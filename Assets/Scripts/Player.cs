using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float jumpForce = 15;
    [SerializeField] private float moveForce = 40;
    
    
    private Rigidbody rb;
    
    private float hInput;
    private float vInput;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) &&
            Physics.Raycast(transform.position, Vector3.down, transform.localScale.z))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(hInput, 0, vInput).normalized;
        rb.AddForce(movement * moveForce, ForceMode.Force);
    }
    
}
