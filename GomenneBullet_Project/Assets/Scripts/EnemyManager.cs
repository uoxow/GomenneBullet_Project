using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int moveSpeed = 5; // 敵の移動速度

    void Update()
    {   
        // 敵を下方向に移動させる
        transform.position += new Vector3(0, -moveSpeed, 0) * Time.deltaTime;

        if (this.transform.position.y < -6) // 画面の外に出たら削除
        {
            Destroy(this.gameObject);
        }
    }

}