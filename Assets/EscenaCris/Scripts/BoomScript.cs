using UnityEngine;

/// <summary>
/// Funcionamiento de la bomba, explota al colisionar con el jugador.
/// Se desactiva al explotar y se reactiva al pasar un tiempo
/// </summary>
public class BoomScript : MonoBehaviour
{
    public GameObject explosionPrefab;
    private Rigidbody2D rigidBody2D;
    private bool isActive = true;

    /// <summary>
    /// Inicializa el componente Rigidbody2D al inicio del juego.
    /// </summary>
    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Detecta colisiones con otros objetos. Si la bomba está activa y colisiona con el jugador, se produce una explosión.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActive) return;

        if (other.transform.CompareTag("Player"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            AudioScript.instance.SoundBoom();
            Deactivate();
        }
    }

    /// <summary>
    /// Desactiva la bomba y programa su reactivación después de un tiempo.
    /// </summary>
    private void Deactivate()
    {
        isActive = false;
        gameObject.SetActive(false);
        Invoke("Reactivate", 1f);
    }

    /// <summary>
    /// Reactiva la bomba, permitiendo que pueda explotar nuevamente.
    /// </summary>
    public void Reactivate()
    {
        isActive = true;
        gameObject.SetActive(true);
    }
}
