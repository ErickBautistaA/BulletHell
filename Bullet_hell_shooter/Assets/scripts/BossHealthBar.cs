using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public static BossHealthBar Instance;
    public Image fillImage;

    public Slider slider;

    void Start()
    {
        Hide(); 
    }

    void Awake()
    {
        Instance = this;
    }

    public void UpdateHealth(int current, int max)
    {
        float value = (float)current / max;
        slider.value = value;

        // Cambiar color según porcentaje de vida
        if (value > 0.5f)
            fillImage.color = Color.green;
        else if (value > 0.25f)
            fillImage.color = Color.yellow;
        else
            fillImage.color = Color.red;
    }

    public void Hide()
    {
        gameObject.SetActive(true); 
        slider.gameObject.SetActive(false); 
    }

    public void Show()
    {
        slider.gameObject.SetActive(true);
    }
}
