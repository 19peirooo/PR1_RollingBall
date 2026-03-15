using System;
using UnityEngine;

public class BossGem : MonoBehaviour
{
    
    [SerializeField] private AudioClip gemSfx;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            BossFightManager.Instance.DamageBoss();
            AudioManager.Instance.PlaySfx(gemSfx);
            Destroy(gameObject);
        }
    }
}
