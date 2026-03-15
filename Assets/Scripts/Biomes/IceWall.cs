using UnityEngine;

public class IceWall : MonoBehaviour
{
    public float freezeTime = 2f;

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.Freeze(freezeTime);
        }
    }
}
