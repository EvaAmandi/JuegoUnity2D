using UnityEngine;

/// <summary>
/// Controla el comportamiento de salto de un enemigo.
/// </summary>
public class SaltoEnemigo : MonoBehaviour
{
    public float fuerzaSalto;
    public Rigidbody2D rbd;


    /// <summary>
    /// Inicializa el comportamiento de salto repetitivo.
    /// </summary>
    void Start()
    {
        InvokeRepeating("Saltar", 0f, 1f);
    }

    /// <summary>
    /// Realiza el salto del enemigo aplicando una fuerza hacia arriba.
    /// </summary>
    public void Saltar()
    {
        rbd.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
    }
}
