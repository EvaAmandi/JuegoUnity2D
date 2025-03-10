using UnityEngine;

/// <summary>
/// Esta clase controla el movimiento y la duraci�n de las burbujas en el juego.
/// Hace que las burbujas se muevan y desaparezcan despu�s de un tiempo.
/// </summary>
public class BurbujasMovimento : MonoBehaviour
{
   
    public float velocidadAnimacion = 1f;
    private Animator animator;

    /// <summary>
    /// Este m�todo se llama cuando la burbuja aparece en el juego.
    /// Configura c�mo se mover� la burbuja y cu�ndo desaparecer�.
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
