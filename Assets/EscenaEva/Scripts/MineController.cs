using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla el comportamiento de una mina en el juego.
/// Esta clase maneja la interacción de la mina con el jugador,
/// provocando una explosión cuando el jugador la toca.
/// </summary>
public class MineController : MonoBehaviour
{

    public GameObject explosion;

   
    /// <summary>
    /// Se llama cuando otro objeto entra en contacto con la mina.
    /// Si el objeto es el jugador, destruye la mina y crea una explosión.
    /// </summary>
    /// <param name="other">El objeto que ha entrado en contacto con la mina</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
