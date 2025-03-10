using UnityEngine;

/// <summary>
/// Gestiona la reproducción de sonidos en el juego.
/// </summary>
public class SonidoManager : MonoBehaviour
{
    public static SonidoManager Instance { get; private set; }
    [SerializeField] private AudioClip[] audios;
    private AudioSource controlAudio;

    private float _originalVolume; 

    /// <summary>
    /// Inicializa el componente AudioSource al inicio.
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }

        controlAudio = GetComponent<AudioSource>();
        _originalVolume = controlAudio.volume; 
    }

    /// <summary>
    /// Reproduce un sonido específico según el índice y volumen proporcionados.
    /// </summary>
    /// <param name="indice">Índice del clip de audio en el array.</param>
    /// <param name="volumen">Volumen al que se reproducirá el sonido.</param>
    public void SeleccionAudio(int indice, float volumen)
    {
        if (indice < 0 || indice >= audios.Length) return;
        if (controlAudio != null)
        {
            controlAudio.PlayOneShot(audios[indice], volumen);
        }
    }

    /// <summary>
    /// Mutea o desmutea todos los sonidos.
    /// </summary>
    ///  /// <param name="mute">Valor booleano para mutear o desmutear el sonido.</param>
    public void MuteAllSounds(bool mute)
    {
        controlAudio.volume = mute ? 0 : _originalVolume;
    }

    /// <summary>
    /// Restaura el volumen original de los sonidos.
    /// </summary>
    public void RestoreAllSounds()
    {
        controlAudio.volume = _originalVolume; 
    }

    /// <summary>
    /// Devuelve si el sonido está muteado.
    /// </summary>
    /// <returns>True si el sonido está muteado, False en caso contrario.</returns>
    public bool IsMuted()
    {
        return controlAudio.volume == 0;
    }
}
