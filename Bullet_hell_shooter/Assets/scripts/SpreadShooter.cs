using UnityEngine;

public class SpreadShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f;
    private float cooldown;

    void Start()
    {
        cooldown = Random.Range(0f, fireRate);
    }

    void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0f)
        {
            ShootSpread();
            cooldown = fireRate;
        }
    }

    void ShootSpread()
    {
        float[] angles = { -15f, 0f, 15f };

        foreach (float angle in angles)
        {
            // Aquí es donde va la rotación con el ángulo
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, angle));
        }
    }
}
