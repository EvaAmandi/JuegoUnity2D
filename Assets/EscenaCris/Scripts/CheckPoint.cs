using UnityEngine;

/// <summary>
/// Gestiona el comportamiento de un punto de control (checkpoint) en el juego.
/// </summary>
public class CheckPoint : MonoBehaviour
{
    RespawnPosition respawnPosition;
    public Transform respawnPoint;
    private bool checkpointActivated = false;  

    /// <summary>
    /// Inicializa la referencia al componente RespawnPosition del jugador.
    /// </summary>
    private void Awake()
    {
        respawnPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<RespawnPosition>();
    }

    /// <summary>
    /// Detecta cuando el jugador entra en contacto con el checkpoint y actualiza el punto de reaparición.
    /// </summary>
    /// <param name="collision">Información sobre la colisión.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !checkpointActivated)
        {
            respawnPosition.UpdateCheckPoint(respawnPoint.position);
            checkpointActivated = true; 

        }
    }
}
