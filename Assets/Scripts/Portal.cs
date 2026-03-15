using UnityEngine;

public class Portal : MonoBehaviour
{

    [SerializeField] private int sceneToLoad;
    [SerializeField] private AudioClip portalSfx;

    public void Enter()
    {
        GameManager.Instance.LoadNewScene(sceneToLoad);
        AudioManager.Instance.PlaySfx(portalSfx);
    }

}