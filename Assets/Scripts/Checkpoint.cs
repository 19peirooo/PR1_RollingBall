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
            GameManager.Instance.SetSpawnPoint(new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z));
            disabledCheckpoint = true;
        }
    }
}
