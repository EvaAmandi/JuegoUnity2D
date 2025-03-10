using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Gestiona la configuración global del sonido para todo el juego, incluyendo el volumen y el estado de silencio.
/// Este script asegura que la configuración del sonido persista a través de las diferentes escenas.
/// </summary>
public class GlobalSoundManager : MonoBehaviour
{
    /// <summary>
    /// Obtiene la instancia singleton del GlobalSoundManager.
    /// </summary>
    public static GlobalSoundManager Instance { get; private set; }

    private float _volumenGlobal = 0.5f;
    private bool _isMuted = false;
    private float _lastNonZeroVolume = 0.5f;

    /// <summary>
    /// Obtiene o establece el volumen global del juego.
    /// Al establecer el volumen, limita el valor entre 0 y 1 y actualiza el estado de silencio en consecuencia.
    /// </summary>
    public float VolumenGlobal
    {
        get => _isMuted ? 0 : _volumenGlobal;
        set
        {
            _volumenGlobal = Mathf.Clamp01(value);
            if (_volumenGlobal > 0)
            {
                _lastNonZeroVolume = _volumenGlobal;
                _isMuted = false;
            }
            else
            {
                _isMuted = true;
            }
            ApplyVolumeSettings();
        }
    }

    /// <summary>
    /// Obtiene o establece si el juego está silenciado o no.
    /// Al establecer el estado de silencio, aplica la nueva configuración inmediatamente.
    /// </summary>
    public bool IsMuted
    {
        get => _isMuted;
        set
        {
            _isMuted = value;
            ApplyVolumeSettings();
        }
    }

    /// <summary>
    /// Se llama cuando se carga la instancia del script.
    /// Implementa el patrón singleton para asegurar que solo exista una instancia del GlobalSoundManager.
    /// También, evita que el objeto sea destruido al cargar una nueva escena.
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
    }

    /// <summary>
    /// Aplica la configuración de volumen y silencio actual a todos los componentes de audio relevantes en el juego.
    /// Esto incluye el AudioListener, AudioSources, y otros gestores de sonido.
    /// </summary>
    public void ApplyVolumeSettings()
    {
        AudioListener.volume = _isMuted ? 0 : _volumenGlobal;
        UpdateAllAudioSources();

       
        if (AudioScript.instance != null)
        {
            AudioScript.instance.MuteAllSounds(_isMuted);
        }

        if (SonidoManager.Instance != null)
        {
            SonidoManager.Instance.MuteAllSounds(_isMuted);
        }

        if (ControladorSonido.Instance != null)
        {
            AudioSource controladorSonidoAudioSource = ControladorSonido.Instance.GetComponent<AudioSource>();
            if (controladorSonidoAudioSource != null)
            {
                controladorSonidoAudioSource.volume = _isMuted ? 0 : _volumenGlobal;
            }
        }
    }

    /// <summary>
    /// Actualiza el volumen de todos los componentes AudioSource en la escena basándose en la configuración de volumen y silencio actual.
    /// </summary>
    private void UpdateAllAudioSources()
    {
        AudioSource[] allAudioSources =
        FindObjectsByType<AudioSource>(FindObjectsSortMode.None);
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.volume = _isMuted ? 0 : _volumenGlobal;
        }
    }

    /// <summary>
    /// Alterna el estado de silencio del juego.
    /// Si el juego está actualmente silenciado, lo desactiva y restaura el último volumen.
    /// Si el juego no está silenciado, lo silencia.
    /// </summary>
    public void ToggleMute()
    {
        if (_isMuted)
        {
            _isMuted = false;
            _volumenGlobal = _lastNonZeroVolume;
        }
        else
        {
            _isMuted = true;
        }
        ApplyVolumeSettings();
    }

    /// <summary>
    /// Se llama cuando se carga una nueva escena.
    /// Aplica la configuración de volumen actual a la nueva escena.
    /// </summary>
    /// <param name="scene">La escena recién cargada.</param>
    /// <param name="mode">El LoadSceneMode utilizado para cargar la escena.</param>
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ApplyVolumeSettings();

    }

    /// <summary>
    /// Se llama cuando el objeto se activa y está activo.
    /// Se suscribe al evento sceneLoaded para aplicar la configuración de volumen cuando se carga una nueva escena.
    /// </summary>
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    /// <summary>
    /// Se llama cuando el objeto se desactiva o está inactivo.
    /// Se desuscribe del evento sceneLoaded para evitar fugas de memoria.
    /// </summary>
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
