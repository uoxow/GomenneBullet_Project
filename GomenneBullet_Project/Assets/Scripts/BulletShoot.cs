using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    
    public GameObject bulletPosition;
    public GameObject bulletPrefab;
    public float interval ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("Shoot", 0f , interval );
    }

    // Update is called once per frame
    void Shoot()
    {
        //弾発射
        Instantiate(bulletPrefab, bulletPosition.transform.position, transform.rotation);
    }
}