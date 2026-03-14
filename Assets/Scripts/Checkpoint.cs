using System;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    private bool disabledCheckpoint = false;
    
    private void OnCollisionEnter(Collision other)
    {
        if (disabledCheckpoint) return;
        if (other.gameObject.TryGetComponent(out Player player))
        {
            GameManager.Instance.SetSpawnPoint(this.transform.position);
            disabledCheckpoint = true;
        }
    }
}
