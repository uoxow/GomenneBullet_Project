using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    
    public GameObject bulletPosition;
    public GameObject bulletPrefab;
    public float interval ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        InvokeRepeating("Shoot", 3f , interval );
    }

    // Update is called once per frame
    void Shoot()
    {
        if (GameManager.Instance != null && 
            GameManager.Instance.IsGameActive && 
            !GameManager.Instance.isGameOver && 
            !GameManager.Instance.isGameClear) 
        {
            //弾発射
            Instantiate(bulletPrefab, bulletPosition.transform.position, transform.rotation);;
        }
        
    }
}