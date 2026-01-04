using UnityEngine;

public class GameEndAnimations : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject GameOverScreen;
    [SerializeField]
    private GameObject GameClearScreen;

    void Start()
    {
        GameManager.Instance.OnGameOver += sorrow;
        GameManager.Instance.OnGameClear += happiness;
        GameClearScreen.SetActive(false);
        GameOverScreen.SetActive(false);
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

    void ShowClearScreen()
    {
        GameClearScreen.SetActive(true); 
    }   

    void ShowGameOverScreen()
    {
        GameOverScreen.SetActive(true); 
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
