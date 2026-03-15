using UnityEngine;

public class BossFightManager : MonoBehaviour
{
    
    public static BossFightManager Instance { get; private set; }
    
    [SerializeField] private int bossHP = 4; 
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DamageBoss()
    {
        bossHP--;
        if (bossHP <= 0)
        {
            GameManager.Instance.Victory();
        }
    }
    
    
    
}
