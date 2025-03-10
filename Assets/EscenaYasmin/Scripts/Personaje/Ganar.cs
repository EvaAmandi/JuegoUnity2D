using UnityEngine;

/// <summary>
/// Controla la lógica de victoria del juego, incluyendo la activación del panel de victoria y la transición a la siguiente escena.
/// </summary>
public class Ganar : MonoBehaviour
{
    public GameObject winPanel;
    [SerializeField] private GameObject botonesADeshabilitar;
    [SerializeField] private GameObject panelTiempo;

    private Movimiento movimiento;
    private TimeScript timeScript;
    private SonidoManager sonidoManager;
    [SerializeField] private AudioClip sonidoVictoria;

    /// <summary>
    /// Inicializa las referencias y configura el estado inicial.
    /// </summary>
    void Start()
    {
        sonidoManager = FindAnyObjectByType<SonidoManager>();
        timeScript = FindAnyObjectByType<TimeScript>();
        movimiento = GameObject.FindGameObjectWithTag("Player").GetComponent<Movimiento>();

        if (winPanel != null)
            winPanel.SetActive(false);
    }

    /// <summary>
    /// Detecta la colisión con el jugador y activa la secuencia de victoria.
    /// </summary>
    /// <param name="collision">Información de la colisión.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (sonidoManager != null && sonidoVictoria != null)
            {
                AudioSource audioSource = sonidoManager.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.PlayOneShot(sonidoVictoria);
                }
            }

            if (winPanel != null)
            {
                winPanel.SetActive(true);
                botonesADeshabilitar.SetActive(false);
                panelTiempo.SetActive(false);
            }

            if (movimiento != null)
            {
                movimiento.enabled = false;
            }

            SceneChanger sceneChanger = FindFirstObjectByType<SceneChanger>();
            if (sceneChanger != null)
            {
                timeScript.DetenerTiempo();
                sceneChanger.CambiarASiguienteEscena();
            }
        }
    }
}
