using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using static UnityEngine.Rendering.DebugUI;
/// <summary>
/// Controla el cambio entre escenas del juego.
/// Maneja la transición a la siguiente escena o al menú principal,
/// incluyendo situaciones como completar un nivel o la muerte del jugador.
/// </summary>
public class CambioEscena : MonoBehaviour
{
    public string nombreSiguienteEscena = "Final";
    public string nombreEscenaMenu = "MenuPrincipal";
    private bool cambioEnProceso = false;
    
    /// <summary>
    /// Se activa cuando el jugador entra en contacto con el objeto que tiene este script.
    /// Inicia el proceso de cambio de escena si no está ya en progreso.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !cambioEnProceso)
        {
            MostrarPanelYCambiarEscena(other.gameObject);
        }
    }

    /// <summary>
    /// Muestra el panel de nivel superado y programa el cambio de escena.
    /// Si es la última escena, cambia al menú principal después de un tiempo de espera.
    /// </summary>
    private void MostrarPanelYCambiarEscena(GameObject player)
    {
        cambioEnProceso = true;
        GameManager.Instance.ShowPanelWin();
        player.GetComponent<PlayerMove>().CanMove = false;
    
        SceneManager.LoadScene("Final");

    }
}
