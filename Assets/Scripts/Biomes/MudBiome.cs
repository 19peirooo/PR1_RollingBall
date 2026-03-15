using UnityEngine;

public class MudBiome : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.GetComponent<Rigidbody>().linearDamping *= 2f;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.GetComponent<Rigidbody>().linearDamping /= 2f;
        }
    }
}
