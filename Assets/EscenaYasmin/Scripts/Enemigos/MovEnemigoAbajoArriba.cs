using UnityEngine;

/// <summary>
/// Script para que los enemigos se muevan de abajo a arriba y viceversa.
/// </summary>
public class MovEnemigoAbajoArriba : MonoBehaviour
{
    public float speed;
    public bool esAbajo;
    public float contadorTiempo;
    public float tiempoParaCambiar;

    /// <summary>
    /// Inicializa el contador de tiempo al inicio del juego.
    /// </summary>
    private void Start()
    {
     
        contadorTiempo = tiempoParaCambiar;
    }

    /// <summary>
    /// Actualiza la posición del enemigo y controla el cambio de dirección.
    /// </summary>
    private void Update()
    {
        if (esAbajo)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        contadorTiempo -= Time.deltaTime;
        if (contadorTiempo <= 0)
        {
            contadorTiempo = tiempoParaCambiar;
            esAbajo = !esAbajo; 
        }
    }
}
