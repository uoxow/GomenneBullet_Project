using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void RetryGame()
    {
        // 現在のシーンを再ロード
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.Instance.StartCoroutine(GameManager.Instance.GameStartSequence());
    }
}