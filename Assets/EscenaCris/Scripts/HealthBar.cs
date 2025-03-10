using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controla la salud del personaje
/// </summary>
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public int maxHealth = 100;
    private int currentHealth;

    [SerializeField] private Gradient healthBarGradient;
    [SerializeField] private TextMeshProUGUI textoGameOver;

    private Image fillImage;

    /// <summary>
    /// Inicializa la salud al valor máximo, configura la barra de salud y la actualiza.
    /// </summary>
    void Start()
    {
        currentHealth = maxHealth;
        fillImage = slider.fillRect.GetComponent<Image>();
        fillImage.color = Color.green;
        UpdateHealthBar();
    }

    /// <summary>
    /// Establece la salud máxima y actualiza la barra de salud.
    /// </summary>
    /// <param name="health">El valor de salud máxima.</param>
    public void SetMaxHealth(int health)
    {
        maxHealth = health;
        currentHealth = health;
        UpdateHealthBar();
    }

    /// <summary>
    /// Reduce la salud actual en 10 unidades y actualiza la barra de salud.
    /// </summary>
    public void TakeDamage()
    {
        currentHealth -= 10;
        currentHealth = Mathf.Max(currentHealth, 0);
    }

    /// <summary>
    /// Actualiza la barra de salud en cada frame.
    /// </summary>
    void LateUpdate()
    {
        UpdateHealthBar();
    }

    /// <summary>
    /// Actualiza el valor y el color de la barra de salud según la salud actual.
    /// </summary>
    void UpdateHealthBar()
    {
        if (slider == null) return;

        float healthPercentage = (float)currentHealth / maxHealth;
        slider.value = healthPercentage;

        if (fillImage != null)
        {
            Color newColor = healthBarGradient.Evaluate(healthPercentage);
            fillImage.color = newColor;
            fillImage.fillAmount = healthPercentage;
            slider.SetValueWithoutNotify(healthPercentage);
        }

        Canvas.ForceUpdateCanvases();
    }

    /// <summary>
    /// Devuelve la salud actual del objeto.
    /// </summary>
    /// <returns>El valor de la salud actual.</returns>
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
