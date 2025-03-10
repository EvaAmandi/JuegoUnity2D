using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Gestiona el flujo del juego, incluyendo el seguimiento del tiempo, 
/// las condiciones de fin de juego y la aplicación de ajustes de volumen.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public PlayerMove playerMove;
    public Text timeText;

    public GameObject timeOverPanel;
    public GameObject healthOverPanel;
    public GameObject panelNivelSuperado;
    public GameObject panelTiempo;

    public float totalTime = 60f;
    public CambioEscena cambioEscena;

    [SerializeField] private string SceneMenu;
    [SerializeField] private GameObject botonesADeshabilitar;
    private float remainingTime;
    private static bool isGameOver = false;
    public static bool IsGameOver1 { get => isGameOver; set => isGameOver = value; }


    /// <summary>
    /// Inicializa el estado del juego al inicio.
    /// </summary>
    void Start()
    {
        Instance = this;
        isGameOver = false;
        remainingTime = totalTime;
        if (timeOverPanel != null) timeOverPanel.SetActive(false);
        if (healthOverPanel != null) healthOverPanel.SetActive(false);
        if (panelNivelSuperado != null) panelNivelSuperado.SetActive(false);

        ApplyVolumeSettings();
    }

    /// <summary>
    /// Actualiza el tiempo restante y la pantalla en cada frame.
    /// Si el juego no ha terminado y queda tiempo, reduce el tiempo restante.
    /// Si el tiempo se agota, desactiva el panel de tiempo, actualiza la pantalla y muestra el panel de tiempo agotado.
    /// </summary>
    void Update()
    {
        if (!isGameOver)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                UpdateTimeDisplay();
            }
            else
            {
                panelTiempo.SetActive(false);
                remainingTime = 0;
                UpdateTimeDisplay();
                ShowTimeOver();
            }
        }
    }

    /// <summary>
    /// Configura la instancia única del GameManager cuando el juego comienza.
    /// </summary>
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            DestroyInstace();
        }
    }

    /// <summary>
    /// Se ejecuta cada vez que se carga una nueva escena.
    /// </summary>
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "Agua")
        {
            DestroyInstace();
        }
    }

    /// <summary>
    /// Destruye la instancia del GameManager.
    /// </summary>
    public void DestroyInstace()
    {
        Instance = null;
    }

    /// <summary>
    /// Actualiza el texto mostrado del tiempo restante.
    /// </summary>
    void UpdateTimeDisplay()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        int milliseconds = Mathf.FloorToInt((remainingTime % 1) * 100);
        if (minutes < 0) minutes = 0;
        if (seconds < 0) seconds = 0;
        if (milliseconds < 0) milliseconds = 0;
        if (timeText != null)
        {
            timeText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        }
    }

    /// <summary>
    /// Muestra el panel de tiempo agotado, detiene la escena, 
    /// desactiva los botones y guarda el estado del audio.
    /// </summary>
    void ShowTimeOver()
    {
        isGameOver = true;
        GuardarEstadoAudio();

        if (timeOverPanel != null)
        {
            timeOverPanel.SetActive(true);
            botonesADeshabilitar.SetActive(false);
            Time.timeScale = 0;
        }
    }

    /// <summary>
    /// Muestra el panel de salud agotada, detiene la escena, desactiva otros paneles y botones,
    /// y guarda el estado del audio.
    /// </summary>
    public void ShowHealthOver()
    {
        isGameOver = true;
        GuardarEstadoAudio();

        if (healthOverPanel != null)
        {
            panelTiempo.SetActive(false);
            healthOverPanel.SetActive(true);
            botonesADeshabilitar.SetActive(false);
            Time.timeScale = 0;
        }
    }

    /// <summary>
    /// Muestra el panel de 'nivel superado', desactiva los botones y el panel de tiempo, y carga la escena final.
    /// </summary>
    public void ShowPanelWin()
    {
        isGameOver = true;
        if (panelNivelSuperado != null)
        {
            panelNivelSuperado.SetActive(true);
            botonesADeshabilitar.SetActive(false);
            panelTiempo.SetActive(false);
            SceneManager.LoadScene("Final");
        }
    }


    /// <summary>
    /// Devuelve el estado actual del juego (terminado o no).
    /// </summary>
    /// <returns>Verdadero si el juego ha terminado, falso en caso contrario.</returns>
    public static bool IsGameOver()
    {
        return isGameOver;
    }

    /// <summary>
    /// Guarda el estado actual del audio (volumen y silencio) en el GlobalSoundManager.
    /// </summary>
    private void GuardarEstadoAudio()
    {
        if (GlobalSoundManager.Instance != null)
        {
            GlobalSoundManager.Instance.VolumenGlobal = AudioListener.volume;

            GlobalSoundManager.Instance.IsMuted = (AudioListener.volume == 0);
        }
    }

    /// <summary>
    /// Aplica los ajustes de volumen almacenados en el GlobalSoundManager.
    /// </summary>
    public void ApplyVolumeSettings()
    {
        if (GlobalSoundManager.Instance != null)
        {
            GlobalSoundManager.Instance.ApplyVolumeSettings();
        }
    }
}
