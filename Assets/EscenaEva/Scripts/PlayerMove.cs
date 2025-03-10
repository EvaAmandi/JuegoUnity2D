using System;
using UnityEngine;

/// <summary>
/// Controla el movimiento y las acciones del jugador en el juego.
/// Maneja la entrada del usuario, el movimiento, el salto, y la interacción con el entorno acuático.
/// También gestiona la salud del jugador y su respuesta al daño.
/// </summary>
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Eva.HealthBar healthBar;

    public float runSpeed = 1f;
    public float jumpForce = 4f;
    public float maxJumpVelocity = 1f;
    public float resistenciaAgua = 0.8f;
    public SpriteRenderer spriteRenderer;

    private Rigidbody2D rb2D;

    [SerializeField] private AudioClip saltoSonido;

    bool dPressed, aPressed, spacePressed;
    bool canMove = true; 

    public bool CanMove { get => canMove; set => canMove = value; }

    /// <summary>
    /// Inicializa el componente del jugador.
    /// Configura el Rigidbody2D.
    /// </summary>
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.gravityScale = 0.1f;
    }

    /// <summary>
    /// Maneja la entrada del usuario en cada frame.
    /// Detecta las teclas presionadas para el movimiento y el salto.
    /// </summary>
    void Update()
    {
        if (canMove)
        {
            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                dPressed = true;
            }
            else if (Input.GetKey("a") || Input.GetKey("left"))
            {
                aPressed = true;
            }

            if (Input.GetKeyDown("space"))
            {
                spacePressed = true;
            }
        }
    }

    /// <summary>
    /// Aplica el movimiento físico al jugador.
    /// Se ejecuta a intervalos fijos para una física más precisa.
    /// </summary>
    void FixedUpdate()
    {
        if (dPressed)
        {
            rb2D.transform.Translate(Vector2.right * runSpeed * Time.deltaTime);
            spriteRenderer.flipX = false;
            dPressed = false;
        }
        else if (aPressed)
        {
            rb2D.transform.Translate(Vector2.left * runSpeed * Time.deltaTime);
            spriteRenderer.flipX = true;
            aPressed = false;
        }

        if (spacePressed)
        {
            Saltar();
            spacePressed = false;
        }
       
        if (rb2D.linearVelocity.y > maxJumpVelocity)
        {
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, maxJumpVelocity);
        }

      
        rb2D.linearVelocity += -rb2D.linearVelocity * resistenciaAgua * Time.fixedDeltaTime;
    }

    /// <summary>
    /// Hace que el jugador salte aplicando una fuerza hacia arriba.
    /// También reproduce un sonido de salto.
    /// </summary>
    void Saltar()
    {
        Vector2 impulso = new Vector2(0, jumpForce);
        rb2D.AddForce(impulso, ForceMode2D.Impulse);
        ControladorSonido.Instance.EjecutarSonido(saltoSonido);
    }

    /// <summary>
    /// Aplica daño al jugador, actualiza la barra de salud y verifica si el jugador ha muerto.
    /// Si la salud llega a cero, desactiva el movimiento y muestra el panel de fin de juego.
    /// </summary>
    public void daño()
    {
        if (GameManager.IsGameOver()) return;
        healthBar.TakeDamage();

        if (healthBar.GetCurrentHealth() <= 0)
        {
            canMove = false; 
            GameManager.Instance.ShowHealthOver(); 
        }
    }
}
