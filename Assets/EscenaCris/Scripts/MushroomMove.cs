using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Controla el movimiento y las acciones del personaje, incluyendo saltos, daño y colisiones.
/// </summary>
public class MushroomMove : MonoBehaviour
{
    public bool colPies = true;
    [SerializeField] private bool dano;
    [SerializeField] private float JumpForce;
    private float Horizontal;
    private Rigidbody2D rigidBody2D;
    private bool Grounded = true;
    private bool canMove;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private CapsuleCollider2D sensorDeRotacion;
    private TimeScript timeScript;
    float airTime;
    [SerializeField] private TextMeshProUGUI textoDeath;
    [SerializeField] private GameObject panelMuerte;
    [SerializeField] private GameObject botonesADeshabilitar;
    [SerializeField] private GameObject musicaDeshabilitar;
    [SerializeField] private GameObject panelTime;

    /// <summary>
    /// Obtiene o establece si el personaje puede moverse o no.
    /// </summary>
    public bool CanMove { get => canMove; set => canMove = value; }

    /// <summary>
    /// Inicializa componentes y variables al inicio del juego.
    /// </summary>
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        CanMove = true;
        if (healthBar == null)
        {
            healthBar = GetComponent<HealthBar>();
        }
        sensorDeRotacion.gameObject.SetActive(false);
        timeScript = FindAnyObjectByType<TimeScript>();
        textoDeath.gameObject.SetActive(false);
        panelMuerte.SetActive(false);
    }

    /// <summary>
    /// Actualiza el movimiento y las acciones del personaje en cada frame.
    /// </summary>
    void Update()
    {
        if (!CanMove) return;
        Horizontal = Input.GetAxisRaw("Horizontal");
        Grounded = CheckGround.colPies;

        if (airTime > 0)
        {
            airTime -= Time.deltaTime;
            if (airTime < 0) airTime = 0;
        }

        if (Grounded && airTime == 0)
        {
            if (sensorDeRotacion.isActiveAndEnabled)
            {
                sensorDeRotacion.gameObject.SetActive(false);
                rigidBody2D.angularVelocity = 0;
                transform.eulerAngles = Vector3.zero;
                rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }

        if (Grounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    /// <summary>
    /// Realiza el salto del personaje aplicando una fuerza hacia arriba.
    /// </summary>
    private void Jump()
    {
        rigidBody2D.AddForce(Vector2.up * JumpForce);
        AudioScript.instance.SoundJump();
    }

    /// <summary>
    /// Actualiza el movimiento horizontal y la rotación del personaje en intervalos fijos.
    /// </summary>
    private void FixedUpdate()
    {
        if (!CanMove) return;
        if (Horizontal < 0.0f) transform.localScale = new Vector3(0.65f, 0.65f, 1f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(-0.65f, 0.65f, 1.0f);

        rigidBody2D.linearVelocity = new Vector2(Horizontal, rigidBody2D.linearVelocity.y);
    }

    /// <summary>
    /// Detecta colisiones con plataformas móviles y ajusta el movimiento del personaje.
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovePlataform"))
        {
            transform.parent = collision.transform;
        }
    }

    /// <summary>
    /// Detecta cuando el personaje deja de colisionar con plataformas móviles.
    /// </summary>
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovePlataform"))
        {
            transform.parent = null;
        }
    }

    /// <summary>
    /// Aplica daño al personaje y verifica si su salud llega a 0, muestra el panel de muerte y oculta los que no son necesarios.
    /// </summary>
    public void daño()
    {
        healthBar.TakeDamage();

        if (healthBar.GetCurrentHealth() <= 0)
        {
            GuardarEstadoAudio();
            CanMove = false;
            timeScript.DetenerTiempo();
            textoDeath.gameObject.SetActive(true);
            panelMuerte.SetActive(true);
            Time.timeScale = 0;
            botonesADeshabilitar.SetActive(false);
            panelTime.SetActive(false);
        }
    }

    /// <summary>
    /// Función para guardar el estado del audio en GlobalSoundManager.
    /// </summary>
    private void GuardarEstadoAudio()
    {
        if (GlobalSoundManager.Instance != null)
        {
            GlobalSoundManager.Instance.VolumenGlobal = AudioListener.volume;

            GlobalSoundManager.Instance.IsMuted = (AudioListener.volume == 0);
        }
    }

    /// <summary>
    /// Realiza un salto especial con efecto de giro (trampolín).
    /// </summary>
    public void TrampolinSalto()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        rigidBody2D.linearVelocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddTorque(JumpForce * 10);
        sensorDeRotacion.gameObject.SetActive(true);
        airTime = 1f;
    }

    /// <summary>
    /// Detiene el movimiento del personaje y reinicia su velocidad.
    /// </summary>
    public void StopMovement()
    {
        CanMove = false;
        rigidBody2D.linearVelocity = Vector2.zero;
    }
}
