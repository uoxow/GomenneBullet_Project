using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    void Start()
    {
        GameManager.Instance.OnGameOver += L2DZoom;
        GameManager.Instance.OnGameClear += L2DZoom;
    }

    void L2DZoom()
    {
        Debug.Log("ズーム開始");
        animator.SetTrigger("Zoom");
    }


    void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnGameOver -= L2DZoom;
            GameManager.Instance.OnGameClear -= L2DZoom;
        }
    }
}
