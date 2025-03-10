using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Controla el tiempo de la partida, mostrando un cronómetro y gestionando el fin del juego.
/// </summary>
public class TimeScript : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI textoTiempo;
    [SerializeField] private float tiempo;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject panelTime;
    private MenuSceneScript menuSceneScript;
    private bool finPartida;
    private int tiempoMinutos, tiempoSegundos, tiempoDecimasSegundos;
    [SerializeField] private GameObject botonesADeshabilitar;

    private AudioSource musicaFondo; 

    /// <summary>
    /// Inicializa el panel de Game Over como inactivo al inicio del juego.
    /// </summary>
    void Start()
    {
        gameOverPanel.SetActive(false);
        menuSceneScript = FindAnyObjectByType<MenuSceneScript>();
        musicaFondo = Camera.main.GetComponent<AudioSource>();
    }

    /// <summary>
    /// Actualiza y muestra el tiempo restante, y al llegar a cero, finaliza la partida deteniendo la música 
    /// y la escena, desactivando elementos relacionados con el tiempo e iniciando 
    /// la secuencia de Game Over.
    /// </summary>
    void Reloj()
    {
        if (!finPartida)
        {
            tiempo -= Time.deltaTime;
        }

        tiempoMinutos = Mathf.FloorToInt(tiempo / 60);
        tiempoSegundos = Mathf.FloorToInt(tiempo % 60);
        tiempoDecimasSegundos = Mathf.FloorToInt((tiempo % 1) * 100);

        textoTiempo.text = string.Format("{0:00}:{1:00}:{2:00}",
         tiempoMinutos, tiempoSegundos, tiempoDecimasSegundos);

        if (tiempo <= 0)
        {
            finPartida = true;
            tiempo = 0;

            textoTiempo.gameObject.SetActive(false);
            botonesADeshabilitar.SetActive(false);
            panelTime.SetActive(false);

            
            GuardarEstadoAudio();

            var mushroomMove = FindAnyObjectByType<MushroomMove>();
            if (mushroomMove != null)
            {
                mushroomMove.StopMovement();
            }

            var movimiento = FindAnyObjectByType<Movimiento>();
            if (movimiento != null)
            {
                movimiento.StopMovement();
            }

            gameOverPanel.SetActive(true);
            DetenerTiempo();
            Time.timeScale = 0;
        }
    }

    /// <summary>
    /// Restaura el sonido al estado anterior.
    /// </summary>
    public void RestoreSounds()
    {
      
        if (AudioScript.instance != null)
        {
            AudioScript.instance.RestoreAllSounds();
        }

        
        var sonidoManager = FindAnyObjectByType<SonidoManager>();
        if (sonidoManager != null)
        {
            sonidoManager.RestoreAllSounds();
        }
    }

    /// <summary>
    /// Detiene el tiempo de la partida y congela el juego.
    /// </summary>
    public void DetenerTiempo()
    {
        finPartida = true;
        if (AudioScript.instance != null)
        {
            AudioScript.instance.StopAllSounds();
        }
    }

    /// <summary>
    /// Actualiza el cronómetro en cada frame.
    /// </summary>
    void Update()
    {
        Reloj();
    }

    /// <summary>
    /// Función para guardar el estado del audio en GlobalSoundManager.
    /// </summary>
    private void GuardarEstadoAudio()
    {
        if (GlobalSoundManager.Instance != null)
        {
            
            GlobalSoundManager.Instance.VolumenGlobal = AudioListener.volume;

            GlobalSoundManager.Instance.IsMuted = (AudioListener.volume == 0);
        }
    }
}
