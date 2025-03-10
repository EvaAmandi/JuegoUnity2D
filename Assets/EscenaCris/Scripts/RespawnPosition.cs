using System.Collections;
using UnityEngine;

/// <summary>
/// Controla la l�gica de respawn del jugador al tocar una trampa,
/// actualizando la posici�n de respawn con checkpoint y manejando la corrutina de respawn.
/// </summary>
public class RespawnPosition : MonoBehaviour
{
    private Vector2 checkPointPos; 
    private SpriteRenderer spriteRenderer; 
    private Rigidbody2D rigidBody2D; 

    /// <summary>
    /// Inicializa los componentes necesarios al cargar el script.
    /// </summary>
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Inicializa la posici�n del checkpoint con la posici�n inicial del objeto.
    /// </summary>
    private void Start()
    {
        checkPointPos = transform.position;
    }

    /// <summary>
    /// Detecta cuando el objeto colisiona con un trigger y verifica si es una trampa.
    /// </summary>
    /// <param name="collision">El collider del objeto que entra en el trigger.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trampa"))
        {
            Damage();
        }
    }

    /// <summary>
    /// Actualiza la posici�n del checkpoint a una nueva posici�n especificada.
    /// </summary>
    /// <param name="pos">La nueva posici�n del checkpoint.</param>
    public void UpdateCheckPoint(Vector2 pos)
    {
        checkPointPos = pos;
    }

    /// <summary>
    /// Inicia la corrutina de respawn cuando el jugador toca una trampa.
    /// </summary>
    void Damage()
    {
        StartCoroutine(Respawn(0.5f));
    }

    /// <summary>
    /// Corrutina que maneja la l�gica de respawn despu�s de un tiempo de espera.
    /// </summary>
    /// <param name="duration">El tiempo de espera antes de respawnear.</param>
    /// <returns>IEnumerator para manejar la corrutina.</returns>
    IEnumerator Respawn(float duration)
    {
        yield return new WaitForSeconds(duration);

        transform.position = checkPointPos; 
        transform.localScale = new Vector3(0.65f, 0.65f, 1);
        rigidBody2D.simulated = true;
    }
}
