using TMPro;
using UnityEngine;

/// <summary>
/// Controla la lógica de victoria cuando el jugador alcanza un punto específico.
/// </summary>
public class WinScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoWin;
    [SerializeField] private GameObject fondoWin;
    [SerializeField] private GameObject botonesDeshabilitar;
    [SerializeField] private GameObject panelTiempo;
    [SerializeField] private AudioClip sonidoVictoria; 
    private MushroomMove player;
    private TimeScript timeScript;
    public bool CanMove = true;

    /// <summary>
    /// Inicializa las referencias y desactiva el texto y el panel de victoria al inicio del juego.
    /// </summary>
    private void Start()
    {
        CanMove = true;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MushroomMove>();
        textoWin.gameObject.SetActive(false);
        fondoWin.SetActive(false);
        timeScript = FindAnyObjectByType<TimeScript>();
    }

    /// <summary>
    /// Detecta cuando el jugador colisiona con el objeto final y activa la secuencia de victoria y desactiva otros paneles.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Final"))
        {
            textoWin.gameObject.SetActive(true);
            fondoWin.SetActive(true);
            panelTiempo.SetActive(false);
            botonesDeshabilitar.SetActive(false);
            player.CanMove = false;

        
            ReproducirSonidoVictoria();

            timeScript.DetenerTiempo();

            SceneChanger.Instance.CambiarASiguienteEscena();
        }
    }

    /// <summary>
    /// Reproduce el sonido de victoria usando un AudioSource temporal.
    /// </summary>
    private void ReproducirSonidoVictoria()
    {
        if (sonidoVictoria != null)
        {

            GameObject tempAudioObject = new GameObject("TempAudio");
            AudioSource tempAudioSource = tempAudioObject.AddComponent<AudioSource>();

            tempAudioSource.clip = sonidoVictoria;
            tempAudioSource.volume = 1f; 
            tempAudioSource.Play();

            Destroy(tempAudioObject, sonidoVictoria.length);

        }
    }

}