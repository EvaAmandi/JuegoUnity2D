using UnityEngine;

/// <summary>
/// Controla el movimiento de un enemigo pequeño de derecha a izquierda y viceversa.
/// </summary>
public class MovEnemigoDerechaIzquierdaPequeno : MonoBehaviour
{
   
    public float speed;
    public bool esDerecha;
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
        
        if (esDerecha)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
           
            transform.localScale = new Vector3(-1, 1, 1);
        }
     
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            
            transform.localScale = new Vector3(1, 1, 1);
        }

       
        contadorTiempo -= Time.deltaTime;

        
        if (contadorTiempo <= 0)
        {
            contadorTiempo = tiempoParaCambiar;
            esDerecha = !esDerecha;
        }
    }
}
