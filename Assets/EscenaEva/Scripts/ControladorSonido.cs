using UnityEngine;

/// <summary>
/// Clase que gestiona la reproducción de sonidos en el juego.
/// </summary>
public class ControladorSonido : MonoBehaviour
{
    public static ControladorSonido Instance;
    private AudioSource audioSource;
    [SerializeField] private AudioClip musicaFondo;


    /// <summary>
    /// Instancia única del ControladorSonido.
    /// Se asegura de que solo exista una instancia en todo el juego y
    /// prepara el componente AudioSource para reproducir sonidos.
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
        if (musicaFondo != null)
        {
            audioSource.clip = musicaFondo;
            audioSource.loop = true;
            audioSource.Play();
        }

    }
    /// <summary>
    ///  Aplica los volumenes al audio cuando se active el objeto
    /// </summary>
    private void OnEnable()
    {
        ApplyVolumeSettings();
    }

    /// <summary>
    /// Aplica los ajustes de volumen del GlobalSoundManager.
    /// </summary>
    public void ApplyVolumeSettings()
    {
        if (GlobalSoundManager.Instance != null && audioSource != null)
        {
            audioSource.volume = GlobalSoundManager.Instance.IsMuted ? 0 : GlobalSoundManager.Instance.VolumenGlobal;
        }
    }


    /// <summary>
    /// Reproduce un sonido específico.
    /// Este método permite a otros scripts reproducir efectos de sonido,
    /// simplificando la gestión de audio en todo el juego.
    /// </summary>
    /// <param name="sonido">El AudioClip que se va a reproducir</param>
    public void EjecutarSonido(AudioClip sonido)
    {
        if (audioSource != null && sonido != null)
        {
            audioSource.PlayOneShot(sonido);

        }

    }
}



