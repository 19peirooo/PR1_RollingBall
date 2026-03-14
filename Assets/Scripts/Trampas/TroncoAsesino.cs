using System;
using UnityEngine;

public class TroncoAsesino : MonoBehaviour
{
    
    [SerializeField] private float moveForce = 2f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(0, 0, -1) * moveForce, ForceMode.Force);
    }
}
