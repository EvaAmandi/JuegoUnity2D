using UnityEngine;

/// <summary>
/// Verifica si el objeto está tocando el suelo con una etiqueta terreno utilizando un trigger.
/// </summary>
public class CheckGround : MonoBehaviour
{

    public static bool colPies;

    /// <summary>
    /// Detecta cuando el objeto entra en contacto con el terreno.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Terreno")
        {
            colPies = true;
        }
    }

    /// <summary>
    /// Detecta cuando el objeto deja de estar en contacto con el terreno.
    /// </summary>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Terreno")
        {
            colPies = false;
        }
    }
}
