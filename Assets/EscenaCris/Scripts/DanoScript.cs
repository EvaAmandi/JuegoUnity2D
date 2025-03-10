using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Aplica da�o al jugador cuando entra en contacto con los objetos.
/// Reproduce un sonido y reduce la salud del jugador al colisionar.
/// </summary>
public class DanoJugador : MonoBehaviour
{
    private MushroomMove player;
   


    /// <summary>
    /// Inicializa el componente buscando al jugador.
    /// Se ejecuta autom�ticamente al inicio del juego.
    /// </summary>
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MushroomMove>();
    }
   

    /// <summary>
    /// Detecta cuando el jugador entra en contacto con este objeto.
    /// Cuando ocurre, reproduce un sonido y causa da�o al jugador.
    /// </summary>
    /// <param name="other">El objeto con el que se ha producido la colisi�n</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.da�o();
            AudioScript.instance.SoundHit();
        }
    }
}