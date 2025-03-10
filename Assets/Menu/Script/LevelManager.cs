using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Gestiona la interfaz de usuario del men� principal, incluyendo la visualizaci�n de paneles,
/// la configuraci�n del control deslizante de volumen y la navegaci�n entre escenas.
/// </summary>
public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject historyPanel;
    [SerializeField] private GameObject volumePanel;
    [SerializeField] private Slider volumeSlider;

    /// <summary>
    /// Inicializa el estado del men� principal, configura el control deslizante de volumen
    /// y muestra el men� principal al inicio.
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
    /// Carga la escena del juego con el �ndice 1.
    /// </summary>
    public void BotonStart()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Cierra la aplicaci�n del juego.
    /// </summary>
    public void BotonExit()
    {
        Application.Quit();
    }

    /// <summary>
    /// Muestra el panel del men� principal y oculta los dem�s paneles.
    /// </summary>
    public void ShowMainMenu()
    {
        menuPanel.SetActive(true);
        historyPanel.SetActive(false);
        volumePanel.SetActive(false);
    }

    /// <summary>
    /// Muestra el panel de la historia del juego y oculta los dem�s paneles.
    /// </summary>
    public void ShowHistory()
    {
        menuPanel.SetActive(false);
        historyPanel.SetActive(true);
        volumePanel.SetActive(false);
    }

    /// <summary>
    /// Muestra el panel de configuraci�n de volumen y oculta los dem�s paneles.
    /// </summary>
    public void ShowVolume()
    {
        menuPanel.SetActive(false);
        historyPanel.SetActive(false);
        volumePanel.SetActive(true);
        UpdateVolumeUI();
    }

    /// <summary>
    /// Cambia el volumen global del juego a trav�s del GlobalSoundManager.
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
