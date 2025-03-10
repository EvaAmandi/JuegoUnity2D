using UnityEngine;

/// <summary>
/// Implementa el efecto de parallax para un objeto con SpriteRenderer, 
/// creando una sensación de profundidad en el fondo.
/// </summary>
public class ParallaxEfect : MonoBehaviour
{
    public float parallaxMultiplayer; 
    private float spriteWidth;
    private float startPosition; 
    private Transform cameraTransform; 
    private Vector3 previusCameraPosition; 

    /// <summary>
    /// Inicializa las referencias y variables necesarias al inicio del juego.
    /// </summary>
    void Start()
    {
        cameraTransform = Camera.main.transform; 
        previusCameraPosition = cameraTransform.position;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x; 
        startPosition = transform.position.x; 
    }

    /// <summary>
    /// Aplica el efecto parallax en cada frame, moviendo el objeto en función del desplazamiento de la cámara.
    /// </summary>
    void LateUpdate()
    {
      
        float deltaX = (cameraTransform.position.x - previusCameraPosition.x) * parallaxMultiplayer;
        float moveAmount = cameraTransform.position.x * (1 - parallaxMultiplayer);
        transform.Translate(new Vector3(deltaX, 0, 0));
        previusCameraPosition = cameraTransform.position;

        if (moveAmount > startPosition + spriteWidth)
        {
            transform.Translate(new Vector3(spriteWidth, 0, 0));
            startPosition += spriteWidth;
        }
        else if (moveAmount < startPosition - spriteWidth)
        {
            transform.Translate(new Vector3(-spriteWidth, 0, 0));
            startPosition -= spriteWidth;
        }
    }
}
