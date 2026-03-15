using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Vector3 SpawnPoint { get; private set; } =  Vector3.zero;
    public int Lives { get; private set; } = 5;
    
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip levelMusic;
    [SerializeField] private AudioClip bossMusic;
    [SerializeField] private AudioClip VictoryMusic;
    [SerializeField] private AudioClip DefeatSfx;
    
    
    

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
        LoadSceneMusic(sceneIndex);
        Lives = lives;
    }

    public void LoadSceneMusic(int sceneIndex)
    {
        switch(sceneIndex)
        {
            case 0:
                AudioManager.Instance.PlayMusic(menuMusic);
                Lives = 5;
                break;

            case 1:
            case 2:    
                AudioManager.Instance.PlayMusic(levelMusic);
                break;

            case 3:
                AudioManager.Instance.PlayMusic(bossMusic);
                break;
            case 4:
                AudioManager.Instance.PlayMusic(VictoryMusic);
                break;
            case 5:
                AudioManager.Instance.PlaySfx(DefeatSfx);
                break;
        }
    }

    public void SetSpawnPoint(Vector3 point)
    {
        SpawnPoint = point;
    }

    public void Defeat()
    {
        LoadNewScene(5, Lives);
    }
    
    public void Victory()
    {
        LoadNewScene(4, Lives);
    }
    
}
