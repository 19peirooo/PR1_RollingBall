using UnityEngine;

public class Life : MonoBehaviour
{

    [SerializeField] private int lives;
    
    public int getLives()
    {
        Destroy(gameObject);
        return lives;
    }
    
}
