using UnityEngine;
using System.Collections;

/// <summary>
/// Controla el movimiento de los pajaros entre puntos de patrullaje, ajustando su velocidad y orientación.
/// </summary>
public class PatrullerBird : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float distanciaMin; 
    [SerializeField] private Transform[] puntosMovimientos; 
    private int numAleatorio;
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// Inicializa el objeto seleccionando un punto de movimiento aleatorio y ajustando su orientación.
    /// </summary>
    void Start()
    {
        numAleatorio = Random.Range(0, puntosMovimientos.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        Girar();
    }

    /// <summary>
    /// Actualiza la posición del objeto en cada frame, moviéndolo hacia el punto de movimiento actual.
    /// </summary>
    private void Update()
    {
       
        transform.position = Vector2.MoveTowards(transform.position, puntosMovimientos[numAleatorio].position, velocidad * Time.deltaTime);

        if (Vector2.Distance(transform.position, puntosMovimientos[numAleatorio].position) < distanciaMin)
        {
            numAleatorio = Random.Range(0, puntosMovimientos.Length); 
            Girar();
        }
    }

    /// <summary>
    /// Ajusta la orientación del sprite según la dirección del movimiento.
    /// </summary>
    private void Girar()
    {
     
        if (transform.position.x < puntosMovimientos[numAleatorio].position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
