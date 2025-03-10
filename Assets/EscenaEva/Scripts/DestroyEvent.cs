using UnityEngine;
/// <summary>
/// Controla la destrucción automática de un objeto en el juego.
/// Se utiliza principalmente para eliminar objetos temporales,
/// como efectos visuales, una vez que han completado su propósito.
/// </summary>
public class DestroyEvento : MonoBehaviour
{
    /// <summary>
    /// Destruye el objeto al que está adjunto este script.
    /// Este método está diseñado para ser llamado por un AnimationEvent,
    /// permitiendo que el objeto se elimine automáticamente en un momento
    /// específico de una animación, como al final de un efecto visual.
    /// </summary>
    public void DestroyEvent()
    {
        Destroy(gameObject); 
    }
}
