using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 弾の速度
    private int bulletSpeed = 10;
    void Start() {
        if (GameManager.Instance != null) {
            GameManager.Instance.OnGameOver += DeleteSelf;
            GameManager.Instance.OnGameClear += DeleteSelf;
        }
    }

    void Update()
    {
        if (!GameManager.Instance.IsGameActive) return;
        //弾を動かす
        transform.position += new Vector3(0, bulletSpeed, 0) * Time.deltaTime;
        
        if (this.transform.position.y > 6) // 画面の外に出たら削除
        {
            Destroy(this.gameObject);
        }
    }

    void DeleteSelf() {
        GameManager.Instance.OnGameOver -= DeleteSelf;
        GameManager.Instance.OnGameClear -= DeleteSelf;
        Destroy(this.gameObject);
    }

    void OnDestroy() {
        if (GameManager.Instance != null) {
            GameManager.Instance.OnGameOver -= DeleteSelf;
            GameManager.Instance.OnGameClear -= DeleteSelf;
        }
    }

}