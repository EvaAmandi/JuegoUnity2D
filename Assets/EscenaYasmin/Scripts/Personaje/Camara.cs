using UnityEngine;

/// <summary>
/// Controla la posición de la cámara
/// </summary>
public class Camara : MonoBehaviour
{
    [SerializeField]
    private Transform objetivo;
    [SerializeField]
    public float limiteHorizontal = 5f;

    /// <summary>
    /// Actualiza la posición de la cámara para seguir al personaje.
    /// Se ejecuta después de todas las actualizaciones para un movimiento más fluido.
    /// </summary>
    void LateUpdate()
    {
        
        transform.position = new Vector3(objetivo.position.x, objetivo.position.y, transform.position.z);
    }
}
