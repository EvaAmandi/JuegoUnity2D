using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Gestiona la interfaz de usuario del menú principal, incluyendo la visualización de paneles,
/// la configuración del control deslizante de volumen y la navegación entre escenas.
/// </summary>
public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject historyPanel;
    [SerializeField] private GameObject volumePanel;
    [SerializeField] private Slider volumeSlider;

    /// <summary>
    /// Inicializa el estado del menú principal, configura el control deslizante de volumen
    /// y muestra el menú principal al inicio.
    /// </summary>
    private void Start()
    {
        Time.timeScale = 1;

        if (menuPanel != null) menuPanel.SetActive(false);
        if (historyPanel != null) historyPanel.SetActive(false);
        if (volumePanel != null) volumePanel.SetActive(false);

        ShowMainMenu();

        if (volumeSlider != null && GlobalSoundManager.Instance != null)
        {
            volumeSlider.minValue = 0f;
            volumeSlider.maxValue = 1f;
            volumeSlider.value = GlobalSoundManager.Instance.IsMuted ? 0 : GlobalSoundManager.Instance.VolumenGlobal;
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
        }

        UpdateVolumeUI();
    }

    /// <summary>
    /// Carga la escena del juego con el índice 1.
    /// </summary>
    public void BotonStart()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Cierra la aplicación del juego.
    /// </summary>
    public void BotonExit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Muestra el panel del menú principal y oculta los demás paneles.
    /// </summary>
    public void ShowMainMenu()
    {
        menuPanel.SetActive(true);
        historyPanel.SetActive(false);
        volumePanel.SetActive(false);
    }

    /// <summary>
    /// Muestra el panel de la historia del juego y oculta los demás paneles.
    /// </summary>
    public void ShowHistory()
    {
        menuPanel.SetActive(false);
        historyPanel.SetActive(true);
        volumePanel.SetActive(false);
    }

    /// <summary>
    /// Muestra el panel de configuración de volumen y oculta los demás paneles.
    /// </summary>
    public void ShowVolume()
    {
        menuPanel.SetActive(false);
        historyPanel.SetActive(false);
        volumePanel.SetActive(true);
        UpdateVolumeUI();
    }

    /// <summary>
    /// Cambia el volumen global del juego a través del GlobalSoundManager.
    /// </summary>
    /// <param name="volume">El valor de volumen a establecer.</param>
    public void ChangeVolume(float volume)
    {
        if (GlobalSoundManager.Instance != null)
        {
            GlobalSoundManager.Instance.VolumenGlobal = volume;
        }
    }

    /// <summary>
    /// Actualiza la interfaz de usuario del control deslizante de volumen con el volumen global actual.
    /// </summary>
    private void UpdateVolumeUI()
    {
        if (volumeSlider != null && GlobalSoundManager.Instance != null)
        {
            volumeSlider.value = GlobalSoundManager.Instance.IsMuted ? 0 : GlobalSoundManager.Instance.VolumenGlobal;
        }
    }
}
