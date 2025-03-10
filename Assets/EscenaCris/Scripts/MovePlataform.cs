using UnityEngine;

/// <summary>
/// Controla el movimiento de una plataforma entre dos puntos en un ciclo continuo.
/// </summary>
public class MovePlataform : MonoBehaviour
{
    [SerializeField] private GameObject GameObject;
    [SerializeField] private Transform StartPoint; 
    [SerializeField] private Transform EndPoint;
    [SerializeField] private float Velocidad; 
    private Vector3 Move;

    /// <summary>
    /// Inicializa la posición objetivo de la plataforma al punto final.
    /// </summary>
    void Start()
    {
        Move = EndPoint.position;
    }

    /// <summary>
    /// Mueve la plataforma hacia la posición objetivo y cambia la dirección al llegar a los extremos.
    /// </summary>
    void Update()
    {
        GameObject.transform.position = Vector3.MoveTowards(GameObject.transform.position, Move, Velocidad * Time.deltaTime);

        if (GameObject.transform.position == EndPoint.position)
        {
            Move = StartPoint.position;
        }
        if (GameObject.transform.position == StartPoint.position)
        {
            Move = EndPoint.position;
        }
    }
}
