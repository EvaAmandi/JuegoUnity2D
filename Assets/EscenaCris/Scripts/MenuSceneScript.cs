using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Gestiona la lógica de la interfaz de usuario en la escena del menú, incluyendo la pausa del juego,
/// la configuración de la música, y la confirmación de salida.
/// </summary>
public class MenuSceneScript : MonoBehaviour
{
    [SerializeField] private GameObject panelPausa;
    [SerializeField] private GameObject panelMusica;
    [SerializeField] private GameObject panelExit;
    [SerializeField] private Button muteButton;
    [SerializeField] private Sprite mutedSprite;
    [SerializeField] private Sprite unmutedSprite;

    private bool _wasMutedBeforePause = false;

    /// <summary>
    /// Se llama al inicio de la escena. Aplica el estado del volumen inicial y actualiza la UI del botón de silencio.
    /// </summary>
    private void Start()
    {
       
        if (GlobalSoundManager.Instance != null)
        {
            GlobalSoundManager.Instance.ApplyVolumeSettings();
        }
        UpdateMuteButtonUI();
    }

    /// <summary>
    /// Alterna el estado de silencio del juego y actualiza la interfaz del botón de silencio.
    /// </summary>
    public void ToggleMute()
    {
        if (GlobalSoundManager.Instance != null)
        {
            GlobalSoundManager.Instance.ToggleMute();
            UpdateMuteButtonUI();
        }
    }

    /// <summary>
    /// Muestra u oculta el panel de configuración de la música.
    /// </summary>
    public void TogglePanelMusica()
    {
        if (panelMusica != null)
        {
            panelMusica.SetActive(!panelMusica.activeSelf);
        }
    }

    /// <summary>
    /// Pausa el juego, guarda el estado actual del silencio, silencia temporalmente el juego, 
    /// muestra el panel de pausa y actualiza la UI del boton de silencio.
    /// </summary>
    public void PauseGame()
    {
        if (GlobalSoundManager.Instance != null)
        {
            _wasMutedBeforePause = GlobalSoundManager.Instance.IsMuted;

            GlobalSoundManager.Instance.IsMuted = true;
        }

        if (panelPausa != null)
        {
            panelPausa.SetActive(true);
        }

        Time.timeScale = 0;
        UpdateMuteButtonUI();
    }

    /// <summary>
    /// Reanuda el juego, restaura el estado de silencio previo a la pausa y oculta el panel de pausa.
    /// </summary>
    public void PlayPause()
    {
        if (GlobalSoundManager.Instance != null)
        {
            GlobalSoundManager.Instance.IsMuted = _wasMutedBeforePause;
        }

        if (panelPausa != null)
        {
            panelPausa.SetActive(false);
        }

        Time.timeScale = 1;
        UpdateMuteButtonUI();
    }

    /// <summary>
    /// Muestra el panel de confirmación para salir del juego y silencia temporalmente el juego.
    /// </summary>
    public void MostrarConfirmacionSalir()
    {
        if (GlobalSoundManager.Instance != null)
        {
            _wasMutedBeforePause = GlobalSoundManager.Instance.IsMuted;

            GlobalSoundManager.Instance.IsMuted = true;
        }

        if (panelExit != null)
        {
            panelExit.SetActive(true);
        }

        Time.timeScale = 0;
        UpdateMuteButtonUI();
    }

    /// <summary>
    /// Cancela la acción de salir del juego, restaura el estado de silencio previo y oculta el panel de confirmación de salida.
    /// </summary>
    public void CancelarSalir()
    {
        if (GlobalSoundManager.Instance != null)
        {
            GlobalSoundManager.Instance.IsMuted = _wasMutedBeforePause;
        }

        if (panelExit != null)
        {
            panelExit.SetActive(false);
        }

        Time.timeScale = 1;
        UpdateMuteButtonUI();
    }

    /// <summary>
    /// Sale del juego, restaura el estado de silencio previo, detiene y destruye el AudioScript (si existe)
    /// y carga la escena del menú principal.
    /// </summary>
    public void ExitGame()
    {
        if (GlobalSoundManager.Instance != null)
        {
            GlobalSoundManager.Instance.IsMuted = _wasMutedBeforePause;
        }

        if (AudioScript.instance != null)
        {
            AudioScript.instance.StopAllSounds();
            Destroy(AudioScript.instance.gameObject);
        }

        Time.timeScale = 1;
        SceneManager.LoadScene("MenuPrincipal");
    }

    /// <summary>
    /// Actualiza la interfaz del botón de silencio para reflejar el estado actual del sonido.
    /// </summary>
    private void UpdateMuteButtonUI()
    {
        if (muteButton != null && GlobalSoundManager.Instance != null)
        {
          
            muteButton.image.sprite = GlobalSoundManager.Instance.IsMuted ? mutedSprite : unmutedSprite;
        }
    }
}
