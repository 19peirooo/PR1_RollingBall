using UnityEngine;

public class Portal : MonoBehaviour
{

    [SerializeField] private int sceneToLoad;
    [SerializeField] private AudioClip portalSfx;

    public void Enter(int lives)
    {
        GameManager.Instance.LoadNewScene(sceneToLoad, lives);
        AudioManager.Instance.PlaySfx(portalSfx);
    }

}