using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasSceneChanger : MonoBehaviour
{

    [SerializeField] private Button button;
    [SerializeField] private int sceneToLoad;
    
    void Start()
    {
        button.onClick.AddListener(ChangeScene);
    }
    
    void ChangeScene()
    {
        GameManager.Instance.LoadNewScene(sceneToLoad);
    }

}
