using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (transform.position.y > 20f) // fuera de pantalla
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.CompareTag("Enemy"))
        {
            // Para enemigos normales
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
                enemy.TakeDamage(1);

            // Para el jefe
            BossBehavior boss = other.GetComponent<BossBehavior>();
            if (boss != null)
                boss.TakeDamage(1);

            Destroy(gameObject); 
        }
    }
}
