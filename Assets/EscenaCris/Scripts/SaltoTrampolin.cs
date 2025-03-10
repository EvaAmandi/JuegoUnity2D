using UnityEngine;

/// <summary>
/// Controla la lógica de salto en un trampolín, aplicando una fuerza de salto al jugador y activando animaciones.
/// </summary>
public class SaltoTrampolin : MonoBehaviour
{
    [SerializeField] private Animator animator; 
    [SerializeField] private float jumpForce;  

    /// <summary>
    /// Detecta cuando un objeto entra en el trigger del trampolín y aplica la lógica de salto.
    /// </summary>
    /// <param name="collision">El collider del objeto que entra en el trigger.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = (Vector2.up * jumpForce);
            animator.Play("JumpTrampoline");
            collision.gameObject.GetComponent<MushroomMove>().TrampolinSalto();
        }
    }
}
