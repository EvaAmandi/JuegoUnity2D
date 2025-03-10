using UnityEngine;

/// <summary>
/// Controla el movimiento de un enemigo de izquierda a derecha y viceversa sin cambiar su orientación visual.
/// </summary>
public class MovEnemigoIzquierdaDerechaSinCambioDeCara : MonoBehaviour
{
    public float speed;
    public bool esIzquierda;
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
        if (esIzquierda == true)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (esIzquierda == false)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        contadorTiempo -= Time.deltaTime;

        if (contadorTiempo <= 0)
        {
            contadorTiempo = tiempoParaCambiar;
            esIzquierda = !esIzquierda;
        }
    }
}
