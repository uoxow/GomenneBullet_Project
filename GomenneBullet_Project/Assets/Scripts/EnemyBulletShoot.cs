using UnityEngine;

public class EnemyBulletShoot : MonoBehaviour
{
    
    public GameObject bulletPosition;
    public GameObject bulletPrefab;
    public float interval ;

    [SerializeField]
    private EnemyManager enemyManager;
    public float spreadAngle = 15f; // 弾の広がる角度

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        InvokeRepeating("Shoot", 3f , interval );
    }

    // Update is called once per frame
    void Shoot()
    {
        //弾発射
        Instantiate(bulletPrefab, bulletPosition.transform.position, transform.rotation);
        if(enemyManager.nowGauge >= 6){
            Instantiate(bulletPrefab, bulletPosition.transform.position, transform.rotation);
            // 左側の弾（現在の回転から spreadAngle 分だけ左に回転）
            Quaternion leftRotation = transform.rotation * Quaternion.Euler(0, -spreadAngle, 0);
            Instantiate(bulletPrefab, bulletPosition.transform.position, leftRotation);

            // 右側の弾（現在の回転から spreadAngle 分だけ右に回転）
            Quaternion rightRotation = transform.rotation * Quaternion.Euler(0, spreadAngle, 0);
            Instantiate(bulletPrefab, bulletPosition.transform.position, rightRotation);
        }
    }
}