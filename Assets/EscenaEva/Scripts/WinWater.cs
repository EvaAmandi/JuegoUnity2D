using UnityEngine;
/// <summary>
/// Clase que gestiona la colision y mostrar panel de victoria y cambio a otra escena
/// </summary>
public class WinWater : MonoBehaviour
{

    /// <summary>
    /// Detecta cuando el jugador colisiona con el objeto final y activa la secuencia de victoria.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Final"))
        {
            GameManager.Instance.ShowPanelWin();
        }
    }
}
