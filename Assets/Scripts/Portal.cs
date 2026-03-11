using UnityEngine;

public class Portal : MonoBehaviour
{

    [SerializeField] private int sceneToLoad;

    public void Enter(int lives)
    {
        GameManager.Instance.LoadNewScene(sceneToLoad, lives);
    }

}