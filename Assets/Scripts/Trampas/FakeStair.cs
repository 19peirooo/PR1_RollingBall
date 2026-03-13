using System;
using UnityEngine;

public class FakeStair : MonoBehaviour
{

    private Rigidbody rb;

    private float timer = 2f;
    private bool timerStarted = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void Update()
    {
        if (timerStarted) timer -= Time.deltaTime;
        
        if (timer <= 0f) Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            rb.isKinematic = false;
            timerStarted = true;
        }
    }
}
