using UnityEngine;

public class FakeStair : MonoBehaviour
{

    private Rigidbody rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    
}
