using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Vector3 SpawnPoint { get; private set; } =  Vector3.zero;
    public int Lives { get; private set; } = 5;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadNewScene(int sceneIndex, int lives)
    {
        SceneManager.LoadScene(sceneIndex);
        Lives = lives;
    }

    public void SetSpawnPoint(Vector3 point)
    {
        SpawnPoint = point;
    }

    public void Defeat()
    {
        LoadNewScene(5, Lives);
    }
    
}
