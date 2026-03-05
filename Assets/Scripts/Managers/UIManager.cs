using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        //Si no existe --> Soy yo
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //Si ya existe, lo autodestruyo
        else
        {
            Destroy(this.gameObject);
        }
    }
}
    
