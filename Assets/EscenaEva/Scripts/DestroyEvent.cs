using UnityEngine;
/// <summary>
/// Controla la destrucci�n autom�tica de un objeto en el juego.
/// Se utiliza principalmente para eliminar objetos temporales,
/// como efectos visuales, una vez que han completado su prop�sito.
/// </summary>
public class DestroyEvento : MonoBehaviour
{
    /// <summary>
    /// Destruye el objeto al que est� adjunto este script.
    /// Este m�todo est� dise�ado para ser llamado por un AnimationEvent,
    /// permitiendo que el objeto se elimine autom�ticamente en un momento
    /// espec�fico de una animaci�n, como al final de un efecto visual.
    /// </summary>
    public void DestroyEvent()
    {
        Destroy(gameObject); 
    }
}
