using UnityEngine;

public class BossBehavior : MonoBehaviour
{

    [Header("Disparo")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float fireRate = 1f;
    private float fireCooldown = 0f;

    [Header("Vida")]
    public int maxHealth = 30;
    private int currentHealth;

    public GameObject explosionPrefab;

    [Header("Cambio de patrón")]
    private int currentPattern = 0;
    private float patternTimer = 0f;
    public float patternChangeInterval = 10f;

    [Header("Movimiento")]
    public float descendSpeed = 1f;
    public float moveSpeed = 2f;
    public float targetY = 3f;
    public float moveXRange = 2.4f;

    private bool descending = true;
    private int moveDirection = 1; 

    void Start()
    {
        currentHealth = maxHealth;

        // Mostrar y sincronizar barra de vida desde el inicio
        BossHealthBar.Instance.Show();
        BossHealthBar.Instance.UpdateHealth(currentHealth, maxHealth);

        fireCooldown = 0f;
        patternTimer = 0f;
    }

    void Update()
    {
        HandleMovement();

        // Cambiar patrón cada X segundos
        patternTimer += Time.deltaTime;
        if (patternTimer >= patternChangeInterval)
        {
            currentPattern = (currentPattern + 1) % 3; 
            patternTimer = 0f;
        }

        // Disparar según el patrón actual
        fireCooldown -= Time.deltaTime;
        if (fireCooldown <= 0f)
        {
            FirePattern();
            fireCooldown = fireRate;
        }
    }

    void FirePattern()
    {
        switch (currentPattern)
        {
            case 0:
                FireFan();
                break;
            case 1:
                FireCircle();
                break;
            case 2:
                FirePetal();
                break;
        }
    }

    void FireFan()
    {
        float[] angles = { -30f, -15f, 0f, 15f, 30f };
        foreach (float angle in angles)
        {
            Quaternion rot = Quaternion.Euler(0, 0, angle + 180);
            Instantiate(bulletPrefab, firePoint.position, rot);
        }
    }

    void FireCircle()
    {
        int bulletCount = 12;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * 360f / bulletCount;
            Quaternion rot = Quaternion.Euler(0, 0, angle);
            Instantiate(bulletPrefab, firePoint.position, rot);
        }
    }

    void FirePetal()
{
    int petalCount = 3;           
    int bulletsPerPetal = 5;      
    float spreadAngle = 30f;      

    for (int i = 0; i < petalCount; i++)
    {
        float baseAngle = i * (360f / petalCount);

        for (int j = 0; j < bulletsPerPetal; j++)
        {
            float offset = (j - (bulletsPerPetal - 1) / 2f) * (spreadAngle / bulletsPerPetal);
            float angle = baseAngle + offset;

            Quaternion rot = Quaternion.Euler(0, 0, angle);
            Instantiate(bulletPrefab, firePoint.position, rot);
        }
    }
}


    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        BossHealthBar.Instance.UpdateHealth(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (explosionPrefab != null)
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);

        GameManager.Instance.WinGame();
        
    }

    void HandleMovement()
    {
        if (descending)
        {
            // Mover hacia abajo
            transform.position += Vector3.down * descendSpeed * Time.deltaTime;

            // Verificar si ya llegó
            if (transform.position.y <= targetY)
            {
                descending = false;
            }
        }
        else
        {
            // Movimiento horizontal
            transform.position += Vector3.right * moveDirection * moveSpeed * Time.deltaTime;

            // Rebotar si llega al borde
            if (transform.position.x >= moveXRange)
                moveDirection = -1;
            else if (transform.position.x <= -moveXRange)
                moveDirection = 1;
        }
    }

}
