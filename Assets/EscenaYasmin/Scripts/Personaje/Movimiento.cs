using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Controla el movimiento y salto del personaje en el juego.
/// </summary>
public class Movimiento : MonoBehaviour
{
    public float velocidad = 1f;
    public Rigidbody2D rbd;
    public float fuerza;
    public bool enSuelo = false;
    private bool canMove;
    public SonidoManager sonidoManager;

    /// <summary>
    /// Indica si el personaje puede moverse o no.
    /// </summary>
    public bool CanMove { get => canMove; set => canMove = value; }

    /// <summary>
    /// Inicializa el estado de movimiento del personaje.
    /// </summary>
    private void Start()
    {
        CanMove = true;
    }

    /// <summary>
    /// Actualiza el movimiento y salto del personaje en cada frame.
    /// </summary>
    void Update()
    {
        if (!CanMove) return;

        float velocidadX = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;
        Vector3 posicion = transform.position;
        transform.position = new Vector3(velocidadX + posicion.x, posicion.y, posicion.z);

        
        if (enSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            sonidoManager.SeleccionAudio(0, 0.1f); 
            rbd.AddForce(Vector2.up * fuerza, ForceMode2D.Impulse); 
        }
    }

    /// <summary>
    /// Método para detectar cuando el personaje toca el suelo, permite que salte nuevamente
    /// </summary>
    /// <param name="collision">Información de la colisión.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }

    /// <summary>
    ///  Método para detectar cuando el personaje deja de tocar el suelo, evita el salto mientras está en el aire
    /// </summary>
    /// <param name="collision">Información de la colisión.</param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
        }
    }
    /// <summary>
    /// Detiene el movimiento del personaje.
    /// </summary>
    public void StopMovement()
    {
        CanMove = false;
        rbd.linearVelocity = Vector2.zero;
    }
}
