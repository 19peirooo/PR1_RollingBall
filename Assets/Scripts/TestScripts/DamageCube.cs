using System;
using UnityEngine;

public class DamageCube : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.transform.position = GameManager.Instance.SpawnPoint;
        }
    }
}
