using UnityEngine;

/// <summary>
/// Controla el movimiento de los pinchos en un eje horizontal.
/// </summary>
public class SpikeMove : MonoBehaviour
{
    [SerializeField] private float velocidad = 2f;
    [SerializeField] private float distancia = 1f; 
    private Vector3 inicio; 
    private float tiempo; 

    /// <summary>
    /// Guarda la posición inicial del objeto al inicio del juego.
    /// </summary>
    void Start()
    {
        inicio = transform.position;
    }

    /// <summary>
    /// Calcula el movimiento oscilante usando una función senoidal y lo aplica al objeto.
    /// </summary>
    void Update()
    {
        tiempo += Time.deltaTime * velocidad;
        float desplazamiento = Mathf.Sin(tiempo) * distancia;

        transform.position = inicio + new Vector3(desplazamiento, 0, 0);
    }
}