using UnityEngine;

/// <summary>
/// Script para infligir daño al personaje cuando colisiona con un enemigo.
/// </summary>
public class DañoEnemigo : MonoBehaviour
{
   
    public int damage;
    public Vida vida;

    /// <summary>
    /// Método que se ejecuta cuando este objeto colisiona con otro
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
            vida.RecibirDaño(damage);
        }
    }
}
