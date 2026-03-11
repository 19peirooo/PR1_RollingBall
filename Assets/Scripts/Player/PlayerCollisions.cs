using System;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    
    [SerializeField] private int lives = 5;

    private void Start()
    {
        UIManager.Instance.LivesText.SetText(GameManager.Instance.Lives.ToString());
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Damage damage))
        {
            lives -= damage.ObtenerDamageAmount();
            transform.position = GameManager.Instance.SpawnPoint;
            UIManager.Instance.LivesText.SetText(lives.ToString());
        }
        else if (other.gameObject.TryGetComponent(out Portal portal))
        {
            portal.Enter(lives);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Life life))
        {
            lives += life.getLives();
            UIManager.Instance.LivesText.SetText(lives.ToString());
        }
    }
}
