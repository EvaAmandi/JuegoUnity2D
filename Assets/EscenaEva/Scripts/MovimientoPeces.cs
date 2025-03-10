using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Controla el movimiento de los peces en el juego.
/// Este script hace que los peces se muevan de lado a lado y cambien de direcci�n peri�dicamente,
/// simulando un comportamiento natural de nado.
/// </summary>
public class MovimientoPeces : MonoBehaviour
{
    public float speed = 0.3f;
    public float fishScale = 0.5f; 

    private float turnTimer;
    public float timeTrigger;

    private Rigidbody2D myRigidbody;
    private bool facingRight = true; 

    /// <summary>
    /// Inicializa el pez con su configuraci�n inicial.
    /// Establece el temporizador para el cambio de direcci�n y prepara el componente f�sico.
    /// </summary>
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        turnTimer = 0;
        timeTrigger = 3f;
    }

    /// <summary>
    /// Actualiza el movimiento del pez en cada frame.
    /// Mueve el pez, cuenta el tiempo para el cambio de direcci�n y lo gira cuando es necesario.
    /// </summary>
    void Update()
    {

        transform.Translate(Vector2.right * Time.deltaTime * speed);
        turnTimer += Time.deltaTime;
        if (turnTimer >= timeTrigger)
        {
            turnAround();
            turnTimer = 0;
        }
    }

    /// <summary>
    /// Cambia la direcci�n del pez.
    /// Invierte la escala del pez para que mire en la direcci�n opuesta y cambia su velocidad.
    /// </summary>
    void turnAround()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        speed *= -1;
    }
}
