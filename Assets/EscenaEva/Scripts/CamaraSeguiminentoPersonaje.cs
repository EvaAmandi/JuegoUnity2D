using UnityEngine;
namespace Eva { 
    /// <summary>
    /// Controla el seguimiento de la cámara al personaje en un juego 2D.
    /// Permite que la cámara se mueva horizontalmente siguiendo la posición del jugador.
    /// </summary>
    public class CamaraSeguiminentoPersonaje : MonoBehaviour
    {
        [SerializeField]
        private Transform objetivo;

        [SerializeField] public float limiteHorizontal = 2f; 

        /// <summary>
        /// Actualiza la posición de la cámara para seguir al personaje.
        /// Se ejecuta después de todas las actualizaciones para un movimiento más suave.
        /// </summary>
        void FixedUpdate()
        {
            transform.position = new Vector3(
                objetivo.position.x,
                transform.position.y,
                transform.position.z
            );
        }
    }
}