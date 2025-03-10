using UnityEngine;
namespace Eva { 
    /// <summary>
    /// Controla el seguimiento de la c�mara al personaje en un juego 2D.
    /// Permite que la c�mara se mueva horizontalmente siguiendo la posici�n del jugador.
    /// </summary>
    public class CamaraSeguiminentoPersonaje : MonoBehaviour
    {
        [SerializeField]
        private Transform objetivo;

        [SerializeField] public float limiteHorizontal = 2f; 

        /// <summary>
        /// Actualiza la posici�n de la c�mara para seguir al personaje.
        /// Se ejecuta despu�s de todas las actualizaciones para un movimiento m�s suave.
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