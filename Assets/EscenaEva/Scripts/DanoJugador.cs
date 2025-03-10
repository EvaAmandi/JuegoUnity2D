using UnityEngine;

namespace Eva
{
    /// <summary>
    /// Aplica daño al jugador cuando entra en contacto con este objeto.
    /// Reproduce un sonido y reduce la salud del jugador al colisionar.
    /// </summary>
    public class DanoJugador : MonoBehaviour
    {
        [SerializeField] private AudioClip audioClip;
        private PlayerMove player;

        /// <summary>
        /// Inicializa el componente buscando al jugador en la escena.
        /// Se ejecuta automáticamente al inicio del juego.
        /// </summary>
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();

        }

        /// <summary>
        /// Detecta cuando el jugador entra en contacto con este objeto.
        /// Cuando ocurre, reproduce un sonido y causa daño al jugador.
        /// </summary>
        /// <param name="other">El objeto con el que se ha producido la colisión</param>
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                ControladorSonido.Instance.EjecutarSonido(audioClip);
                player.daño();
                
            }
        }

    }

}