using System;
using UnityEngine;

public class BossGem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            BossFightManager.Instance.DamageBoss();
            Destroy(gameObject);
        }
    }
}
