using UnityEngine;

/// <summary>
/// Esta clase controla el movimiento y la duración de las burbujas en el juego.
/// Hace que las burbujas se muevan y desaparezcan después de un tiempo.
/// </summary>
public class BurbujasMovimento : MonoBehaviour
{
   
    public float velocidadAnimacion = 1f;
    private Animator animator;

    /// <summary>
    /// Este método se llama cuando la burbuja aparece en el juego.
    /// Configura cómo se moverá la burbuja y cuándo desaparecerá.
    /// </summary>
    void Start()
    {
        
        animator = GetComponent<Animator>();

        if (animator != null)
        {
            animator.speed = velocidadAnimacion;
        }

     
        Destroy(gameObject, Random.Range(10f, 30f));
    }

  
}
