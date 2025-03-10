using UnityEngine;

/// <summary>
/// Controla el movimiento de un objeto entre puntos definidos, creando un efecto de recorrido continuo.
/// </summary>
public class SierraAeraeScript : MonoBehaviour
{
    [SerializeField] private GameObject objeto; 
    [SerializeField] private Transform[] puntos;
    [SerializeField] private float velocidad;
    private int indiceActual = 0; 

    /// <summary>
    /// Inicializa la posición del objeto en el primer punto del recorrido.
    /// </summary>
    void Start()
    {
        objeto.transform.position = puntos[0].position;
    }

    /// <summary>
    /// Actualiza el movimiento del objeto en cada frame.
    /// </summary>
    void Update()
    {
        MoverObjeto();
    }

    /// <summary>
    /// Mueve el objeto hacia el punto actual y cambia al siguiente punto cuando se alcanza.
    /// </summary>
    private void MoverObjeto()
    {
        if (indiceActual < puntos.Length)
        {
            objeto.transform.position = Vector3.MoveTowards(objeto.transform.position, puntos[indiceActual].position, velocidad * Time.deltaTime);

            if (Vector3.Distance(objeto.transform.position, puntos[indiceActual].position) < 0.1f)
            {
                indiceActual++; 
            }
        }
        else
        {
            indiceActual = 0; 
        }
    }
}

