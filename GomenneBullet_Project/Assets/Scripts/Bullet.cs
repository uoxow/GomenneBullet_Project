using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 弾の速度
    private int bulletSpeed = 7;

    void Update()
    {
        //弾を動かす
        transform.position += new Vector3(0, bulletSpeed, 0) * Time.deltaTime;
        
        if (this.transform.position.y > 6) // 画面の外に出たら削除
        {
            Destroy(this.gameObject);
        }
    }

}