using UnityEngine;

/// <summary>
/// Controla la l�gica de salto en un trampol�n, aplicando una fuerza de salto al jugador y activando animaciones.
/// </summary>
public class SaltoTrampolin : MonoBehaviour
{
    [SerializeField] private Animator animator; 
    [SerializeField] private float jumpForce;  

    /// <summary>
    /// Detecta cuando un objeto entra en el trigger del trampol�n y aplica la l�gica de salto.
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
