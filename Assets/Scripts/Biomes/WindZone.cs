using System;
using UnityEngine;

public class WindZone : MonoBehaviour
{
    
    [SerializeField] private Vector3 windDirection;
    [SerializeField] private float windForce;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            Rigidbody rb = player.GetComponent<Rigidbody>();
            rb.AddForce(windDirection.normalized * windForce, ForceMode.Impulse);
        }
    }
}
