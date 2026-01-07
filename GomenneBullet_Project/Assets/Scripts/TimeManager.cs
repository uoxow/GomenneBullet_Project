using UnityEngine;

public class TimeManager : MonoBehaviour {

    public float clearTime = 0f; 

    void Update () {
        // GameManagerが存在し、ゲームが進行中（Active）かつ
        // 終わっていない（GameOverでもClearでもない）時だけ時間を進める
        if (GameManager.Instance != null && 
            GameManager.Instance.IsGameActive && 
            !GameManager.Instance.isGameOver && 
            !GameManager.Instance.isGameClear) 
        {
            clearTime += Time.deltaTime;
            // Debug.Log ("経過時間: " + clearTime.ToString("F2") + "秒");
        }
    }
}