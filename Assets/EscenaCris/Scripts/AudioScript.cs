using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Esta clase se encarga de manejar todos los sonidos del juego en la escena actual.
/// </summary>
public class AudioScript : MonoBehaviour
{
    /// <summary>
    /// Instancia estática de AudioScript para implementar el patrón Singleton.
    /// </summary>
    public static AudioScript instance;

    [SerializeField] private AudioSource audioSourceJump;
    [SerializeField] private AudioSource audioSourceHit;
    [SerializeField] private AudioSource audioSourceBoom;
    [SerializeField] private AudioSource audioSourceWin;

    private float _originalVolumeJump;
    private float _originalVolumeHit;
    private float _originalVolumeBoom;
    private float _originalVolumeWin;

    /// <summary>
    /// Se llama automáticamente cuando el juego comienza.
    /// Se asegura de que solo haya una instancia de AudioScript en todo el juego.
    /// Guarda los volúmenes originales de cada AudioSource.
    /// Evita que el objeto se destruya al cargar una nueva escena.
    /// Se suscribe al evento de cambio de escena.
    /// </summary>
    private void Awake()
    {
        if (AudioScript.instance == null)
        {
            AudioScript.instance = this;

            _originalVolumeJump = audioSourceJump.volume;
            _originalVolumeHit = audioSourceHit.volume;
            _originalVolumeBoom = audioSourceBoom.volume;
            _originalVolumeWin = audioSourceWin.volume;

            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Método que se llama cada vez que se carga una nueva escena.
    /// Si la escena cargada es la tercera escena ("Agua"), detiene todos los sonidos y destruye el AudioScript.
    /// Ajusta el volumen
    /// </summary>
    /// <param name="scene">La escena que se ha cargado.</param>
    /// <param name="mode">El modo de carga de la escena.</param>
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Agua")
        {
            StopAllSounds();
            Destroy(gameObject);
        }
        ApplyVolumeSettings();
    }

    /// <summary>
    /// Aplica los ajustes de volumen guardados en GlobalSoundManager.
    /// </summary>
    public void ApplyVolumeSettings()
    {
        if (GlobalSoundManager.Instance != null)
        {
            MuteAllSounds(GlobalSoundManager.Instance.IsMuted);
        }
    }

    /// <summary>
    /// Reproduce el sonido de salto.
    /// </summary>
    public void SoundJump()
    {
        if (audioSourceJump != null)
        {
            audioSourceJump.Play();
        }
    }

    /// <summary>
    /// Reproduce el sonido de golpe.
    /// </summary>
    public void SoundHit()
    {
        if (audioSourceHit != null)
        {
            audioSourceHit.Play();
        }
    }

    /// <summary>
    /// Reproduce el sonido de explosión.
    /// </summary>
    public void SoundBoom()
    {
        if (audioSourceBoom != null)
        {
            audioSourceBoom.Play();
        }
    }

    /// <summary>
    /// Reproduce el sonido de victoria.
    /// </summary>
    public void SoundWin()
    {
        if (audioSourceWin != null)
        {
            audioSourceWin.Play();
        }
    }

    /// <summary>
    /// Mutea o desmutea temporalmente todos los sonidos de la escena.
    /// </summary>
    /// <param name="mute">Valor booleano para indicar si se deben mutear o no los sonidos.</param>
    public void MuteAllSounds(bool mute)
    {
        if (audioSourceJump != null) audioSourceJump.volume = mute ? 0 : _originalVolumeJump;
        if (audioSourceHit != null) audioSourceHit.volume = mute ? 0 : _originalVolumeHit;
        if (audioSourceBoom != null) audioSourceBoom.volume = mute ? 0 : _originalVolumeBoom;
        if (audioSourceWin != null) audioSourceWin.volume = mute ? 0 : _originalVolumeWin;
    }

    /// <summary>
    /// Restaura el volumen original de todos los sonidos de la escena.
    /// </summary>
    public void RestoreAllSounds()
    {
        if (audioSourceJump != null) audioSourceJump.volume = _originalVolumeJump;
        if (audioSourceHit != null) audioSourceHit.volume = _originalVolumeHit;
        if (audioSourceBoom != null) audioSourceBoom.volume = _originalVolumeBoom;
        if (audioSourceWin != null) audioSourceWin.volume = _originalVolumeWin;
    }

    /// <summary>
    /// Detiene todos los sonidos.
    /// </summary>
    public void StopAllSounds()
    {
        if (audioSourceJump != null) audioSourceJump.Stop();
        if (audioSourceHit != null) audioSourceHit.Stop();
        if (audioSourceBoom != null) audioSourceBoom.Stop();
        if (audioSourceWin != null) audioSourceWin.Stop();
    }

    /// <summary>
    /// Se destruye la conexión al evento de cambio de escena para evitar errores de memoria.
    /// </summary>
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
