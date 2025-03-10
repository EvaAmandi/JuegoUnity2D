using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Clase que gestiona el cambio entre escenas en el juego.
/// Implementa el patr�n Singleton para acceso global.
/// </summary>
public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance { get; private set; }

    /// <summary>
    /// Inicializa la instancia �nica de SceneChanger.
    /// </summary>
    private void Awake()
    {
        if (Instance != null)
        {

            Destroy(gameObject);
        }
        Instance = this;
    }


    /// <summary>
    /// Cambia a la siguiente escena en el orden de construcci�n.
    /// </summary>
    public void CambiarASiguienteEscena()
    {
        int siguienteEscenaIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (siguienteEscenaIndex < SceneManager.sceneCountInBuildSettings)
        {
            StartCoroutine(CambiarEscenaCoroutine(siguienteEscenaIndex));
        }
        
    }

    /// <summary>
    /// Corrutina para cambiar de escena con un retraso opcional.
    /// </summary>
    /// <param name="indiceEscena">�ndice de la escena a cargar.</param>
    private System.Collections.IEnumerator CambiarEscenaCoroutine(int indiceEscena)
    {
        yield return new WaitForSecondsRealtime(1f); // Espera opcional
        SceneManager.LoadScene(indiceEscena);
    }
}
