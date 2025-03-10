using UnityEngine;
using UnityEngine.UI;
namespace Eva {
    /// <summary>
    /// Clase que gestiona la barra de salud del personaje en el juego.
    /// Controla la visualización y actualización de la salud del personaje.
    /// </summary>
    public class HealthBar : MonoBehaviour
    {
        public Slider slider;
        public int maxHealth = 100;
        private int currentHealth;
        public GameManager gameManager;
        [SerializeField]
        private Gradient healthBarGradient;
        private Image fillImage;

        /// <summary>
        /// Inicialización de la barra de salud y la actualiza
        /// </summary>
        void Start()
        {
            currentHealth = maxHealth;
            fillImage = slider.fillRect.GetComponent<Image>();   
            fillImage.color = Color.green;
            UpdateHealthBar();
        }

        /// <summary>
        /// Establece la salud máxima y actualiza la barra de vida
        /// </summary>
        public void SetMaxHealth(int health)
        {
            maxHealth = health;
            currentHealth = health;
            UpdateHealthBar();
        }

        /// <summary>
        /// Reduce la salud actual en 10 puntos
        /// </summary>
        public void TakeDamage()
        {
            currentHealth -= 10;
            currentHealth = Mathf.Max(currentHealth, 0);
       
        }

        /// <summary>
        /// Actualiza la barra de salud en cada frame
        /// </summary>
        void LateUpdate()
        {
            UpdateHealthBar();
        }

        // <summary>
        /// Actualiza la apariencia visual de la barra de salud
        /// </summary>
        void UpdateHealthBar()
        {
            float healthPercentage = (float)currentHealth / maxHealth;
            slider.value = healthPercentage;

            if (fillImage != null)
            {
                Color newColor = healthBarGradient.Evaluate(healthPercentage);
                fillImage.color = newColor;
                fillImage.fillAmount = healthPercentage; 
                slider.value = healthPercentage;  
                slider.SetValueWithoutNotify(healthPercentage); 
            }
            Canvas.ForceUpdateCanvases();

            if (currentHealth <= 0)
            {
                gameManager.ShowHealthOver();
            }
        }
        /// <summary>
        /// Devuelve la salud actual del personaje
        /// </summary>
        public int GetCurrentHealth()
        {
            return currentHealth;
        }
    }

}