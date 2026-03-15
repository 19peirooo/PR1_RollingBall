using System;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    
    [SerializeField] private AudioClip bombSfx;
    
    private void OnCollisionEnter(Collision other)
    {
        AudioManager.Instance.PlaySfx(bombSfx);
        Destroy(gameObject);
    }
}
