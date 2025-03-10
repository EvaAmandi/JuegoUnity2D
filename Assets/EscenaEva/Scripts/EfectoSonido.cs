using UnityEngine;

/// <summary>
/// Controla la reproducci�n de un efecto de sonido cuando el jugador interact�a con un objeto.
/// Este script se usa t�picamente en objetos del juego que deben emitir un sonido
/// y luego desaparecer cuando el jugador los toca o recoge.
/// </summary>
public class EfectoSonido : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    /// <summary>
    /// Detecta cuando el jugador entra en contacto con este objeto.
    /// Cuando ocurre el contacto, reproduce el sonido asignado y destruye el objeto.
    /// </summary>
    /// <param name="other">El objeto que ha entrado en contacto con este</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ControladorSonido.Instance.EjecutarSonido(audioClip);
            Destroy(gameObject);
        }
    }
}
