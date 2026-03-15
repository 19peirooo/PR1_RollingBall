using UnityEngine;

public class Life : MonoBehaviour
{

    [SerializeField] private int lives;
    [SerializeField] private AudioClip HeartSfx;
    
    public int getLives()
    {
        Destroy(gameObject);
        AudioManager.Instance.PlaySfx(HeartSfx);
        return lives;
    }
    
}
