using UnityEngine;

public class GameEndAnimations : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    void Start()
    {
        GameManager.Instance.OnGameOver += sorrow;
        GameManager.Instance.OnGameClear += happiness;
    }

    void happiness()
    {
        Debug.Log("happiness再生");
        animator.SetTrigger("happiness");
    }

    void sorrow()
    {
        Debug.Log("sorrow再生");
        animator.SetTrigger("sorrow");
    }


    void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnGameOver -= sorrow;
            GameManager.Instance.OnGameClear -= happiness;
        }
    }
}
