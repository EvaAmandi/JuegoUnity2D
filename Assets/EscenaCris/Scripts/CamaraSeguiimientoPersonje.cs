using UnityEngine;

/// <summary>
/// Controla el seguimiento de la cámara al personaje en un juego 2D.
/// Permite que la cámara se mueva horizontalmente siguiendo la posición del jugador.
/// </summary>
public class CamaraSeguiminentoPersonaje : MonoBehaviour
{
    [SerializeField]
    private Transform objetivo;

    [SerializeField] private float limiteHorizontal; 
   
    /// <summary>
    /// Actualiza la posición de la cámara para seguir al personaje.
    /// Se ejecuta después de todas las actualizaciones para un movimiento más suave.
    /// </summary>
    void LateUpdate()
    {
        
        transform.position = new Vector3(
            objetivo.position.x,
            objetivo.position.y,
            transform.position.z
        );
    }
}