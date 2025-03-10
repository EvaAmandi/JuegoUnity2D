using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Controla la vida del jugador, el da�o recibido y la l�gica de game over.
/// </summary>
public class Vida : MonoBehaviour
{
    public int vidaMax = 100;
    public int vida;
    [SerializeField] yasmin.StatusBar barraDeVida;
    private Movimiento movimiento;
    public GameObject gameOverPanel;
    private SpriteRenderer spriteRenderer;
    private bool estaMuerto = false;
    [SerializeField] private GameObject botonesADeshabilitar;
    [SerializeField] private GameObject panelTime;

    private AudioSource audioFuente;

    public SonidoManager sonidoManager;

    /// <summary>
    /// Obtiene o establece el componente Movimiento del jugador.
    /// </summary>
    public Movimiento Movimiento { get => movimiento; set => movimiento = value; }

    /// <summary>
    /// Inicializa el estado de vida y configura los componentes necesarios.
    /// </summary>
    void Start()
    {
        vida = vidaMax;
        estaMuerto = false;
        barraDeVida.SetState(vida, vidaMax);
        Movimiento = GetComponent<Movimiento>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        audioFuente = Camera.main.GetComponent<AudioSource>();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    /// <summary>
    /// Aplica da�o al jugador y maneja la l�gica de muerte si es necesario.
    /// Muestra el panel de muerte y para la escena.
    /// </summary>
    /// <param name="da�o">Cantidad de da�o a aplicar.</param>
    public void RecibirDa�o(int da�o)
    {
        if (estaMuerto == false)
        {
            vida -= da�o;
            barraDeVida.SetState(vida, vidaMax);
            StartCoroutine(ParpadeoDa�o());

            if (sonidoManager != null)
                sonidoManager.SeleccionAudio(1, 0.1f);

            if (vida <= 0)
            {
                estaMuerto = true;
                DesactivarMovimiento();

                GuardarEstadoAudio();

                
                if (gameOverPanel != null) { 
                    gameOverPanel.SetActive(true);
                    botonesADeshabilitar.SetActive(false);
                    panelTime.SetActive(false);
                    Time.timeScale = 0;
                }
                if (spriteRenderer != null)
                {
                    spriteRenderer.enabled = true;
                }
            }
        }
    }

    /// <summary>
    /// Desactiva el movimiento del personaje y sus diferentes efectos.
    /// </summary>
    public void DesactivarMovimiento()
    {
        if (Movimiento != null)
        {
            Movimiento.enabled = false;
        }
    }

    /// <summary>
    /// Corrutina que hace parpadear al jugador cuando recibe da�o.
    /// </summary>
    IEnumerator ParpadeoDa�o()
    {
        for (int i = 0; i < 3; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
    }

    /// <summary>
    /// Funci�n para guardar el estado del audio en GlobalSoundManager.
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
