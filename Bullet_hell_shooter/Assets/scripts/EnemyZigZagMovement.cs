using UnityEngine;

public class EnemyZigZagMovement : MonoBehaviour
{
    public float verticalSpeed = 1.5f;
    public float horizontalSpeed = 2f;
    public float frequency = 3f; 

    private float startX;

    void Start()
    {
        startX = transform.position.x;
    }


    void Update()
    {
        // Movimiento zigzag horizontal + bajada vertical
        float x = startX + Mathf.Sin(Time.time * frequency) * horizontalSpeed;
        float y = transform.position.y - verticalSpeed * Time.deltaTime;

        transform.position = new Vector3(x, y, 0f);

        // Destruye si sale por abajo
        if (y < -10f)
        {
            Destroy(gameObject);
        }
    }
}
