using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float slowSpeed = 2.5f; 
    private float currentSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        // Limitar al área de juego
        float clampedX = Mathf.Clamp(transform.position.x, -2.4f, 2.4f);
        float clampedY = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        // Elegir velocidad según si Shift está presionado
        currentSpeed = Input.GetKey(KeyCode.LeftShift) ? slowSpeed : normalSpeed;

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveX, moveY);
        transform.Translate(movement * currentSpeed * Time.deltaTime);
    }
}
