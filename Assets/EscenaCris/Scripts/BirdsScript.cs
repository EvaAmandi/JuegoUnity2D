using UnityEngine;

/// <summary>
/// Configuración del movimiento de los pájaros en un ciclo infinito, cuando llega al final, gira y regresa al punto de inicio.
/// </summary>
public class BirdsScript : MonoBehaviour
{
    [SerializeField] private GameObject GameObject;
    [SerializeField] private Transform StartPointBird;
    [SerializeField] private Transform EndPointBird;
    [SerializeField] private float Velocidad;
    private Vector3 Move;

    /// <summary>
    /// Inicializa la posición objetivo del objeto al punto final.
    /// </summary>
    void Start()
    {
        Move = EndPointBird.position;
    }

    /// <summary>
    /// Mueve el objeto hacia la posición objetivo y lo gira cuando llega a los extremos.
    /// </summary>
    void Update()
    {
        GameObject.transform.position = Vector3.MoveTowards(GameObject.transform.position, Move, Velocidad * Time.deltaTime);

        if (GameObject.transform.position == EndPointBird.position)
        {
            GameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            Move = StartPointBird.position;
        }

        if (GameObject.transform.position == StartPointBird.position)
        {
            GameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            Move = EndPointBird.position;
        }
    }
}
