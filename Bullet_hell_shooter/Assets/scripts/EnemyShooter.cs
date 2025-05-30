using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f;
    private float fireCooldown;

    void Start()
    {
        fireCooldown = Random.Range(0f, fireRate); 
    }

    
    void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0f)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 180f)); 
            fireCooldown = fireRate;
        }
    }
}
