using System;
using UnityEngine;

public class Muelle : MonoBehaviour
{
    
    [SerializeField] private Vector3 impulseDirection =  Vector3.up;
    [SerializeField] private float impulseForce = 30f;
    
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            other.gameObject.GetComponentInChildren<Rigidbody>().AddForce(impulseDirection * impulseForce, ForceMode.Impulse);           
        }
    }
}
