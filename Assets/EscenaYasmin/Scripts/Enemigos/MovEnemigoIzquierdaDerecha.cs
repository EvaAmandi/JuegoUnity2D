using UnityEngine;

/// <summary>
/// Controla el movimiento de un enemigo de izquierda a derecha y viceversa.
/// </summary>
public class MovEnemigoIzquierdaDerecha : MonoBehaviour
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
    /// Actualiza la posición del enemigo, controla el cambio de dirección y ajusta la escala para reflejar la dirección.
    /// </summary>
    private void Update()
    {
        if (esIzquierda)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.localScale = new Vector3(-0.055f, 0.065f, 1);
        }
        else
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.localScale = new Vector3(0.055f, 0.065f, 1);
        }

    
        contadorTiempo -= Time.deltaTime;

       
        if (contadorTiempo <= 0)
        {
            contadorTiempo = tiempoParaCambiar;
            esIzquierda = !esIzquierda;
        }
    }
}
