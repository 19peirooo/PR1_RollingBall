using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    
    [SerializeField] private Button playButton;
    
    void Start()
    {
        playButton.onClick.AddListener(StartGame);
    }
    
    void StartGame()
    {
        GameManager.Instance.LoadNewScene(1);
    }

}
