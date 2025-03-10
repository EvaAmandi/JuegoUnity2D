using UnityEngine;

/// <summary>
/// Controla la posici�n de la c�mara
/// </summary>
public class Camara : MonoBehaviour
{
    [SerializeField]
    private Transform objetivo;
    [SerializeField]
    public float limiteHorizontal = 5f;

    /// <summary>
    /// Actualiza la posici�n de la c�mara para seguir al personaje.
    /// Se ejecuta despu�s de todas las actualizaciones para un movimiento m�s fluido.
    /// </summary>
    void LateUpdate()
    {
        
        transform.position = new Vector3(objetivo.position.x, objetivo.position.y, transform.position.z);
    }
}
