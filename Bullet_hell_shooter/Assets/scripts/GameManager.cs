using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameWinCanvas;

    void Awake()
    {
        Instance = this;
        gameWinCanvas.SetActive(false); 
    }

    public void WinGame()
    {
        Debug.Log("¡Ganaste!");
        if (gameWinCanvas != null)
        {
            gameWinCanvas.SetActive(true);
        }

        
        Time.timeScale = 0f;
    }
}
