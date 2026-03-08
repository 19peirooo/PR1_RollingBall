using UnityEngine;

public class Portal : MonoBehaviour
{

    [SerializeField] private int sceneToLoad;

    public void Enter()
    {
        GameManager.Instance.LoadNewScene(sceneToLoad);
    }

}
