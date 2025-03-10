using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;

/// <summary>
/// Controla la animaci�n y visualizaci�n del panel de inicio del juego.
/// </summary>
public class PanelPrincipio : MonoBehaviour
{
    public Text mainTitleText;
    public Text subtitleText;
    public float typingSpeed = 0.1f;
    public float delayBetweenTexts = 1f;
    public float displayDuration = 5f;

    public GameObject panelPortada;
    public GameObject panelMainMenu;

    public bool mostrarPortada = true;
    private static bool portadaMostrada = false;

    /// <summary>
    /// Inicializa la visualizaci�n de la portada o el men� principal.
    /// </summary>
    void Start()
    {
        if (mostrarPortada && !portadaMostrada)
        {
            ShowPortada();
        }
        else
        {
            ShowMainMenu();
        }
    }

    /// <summary>
    /// Muestra la portada y comienza la animaci�n del t�tulo y oculta el panel del men�.
    /// </summary>
    void ShowPortada()
    {
        panelMainMenu.SetActive(false);
        panelPortada.SetActive(true);
        StartCoroutine(AnimateTitle());
    }

    /// <summary>
    /// Muestra el men� principal y desactiva el panel de portada.
    /// </summary>
    void ShowMainMenu()
    {
        panelPortada.SetActive(false);
        panelMainMenu.SetActive(true);
    }

    /// <summary>
    /// Corrutina que genera la aparici�n del t�tulo y subt�tulo y enlaza con el men� principal.
    /// </summary>
    IEnumerator AnimateTitle()
    {
        mainTitleText.text = "";
        subtitleText.text = "";

        yield return StartCoroutine(TypeText(mainTitleText, "SLIME REALM"));
        yield return new WaitForSeconds(delayBetweenTexts);
        yield return StartCoroutine(TypeText(subtitleText, "the union of the elements"));

        yield return new WaitForSeconds(displayDuration);

        portadaMostrada = true;
        ShowMainMenu();
    }

    /// <summary>
    /// Corrutina que simula el efecto de escritura de texto.
    /// </summary>
    /// <param name="textComponent">Componente de texto a animar.</param>
    /// <param name="fullText">Texto completo a mostrar.</param>
    IEnumerator TypeText(Text textComponent, string fullText)
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            textComponent.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    /// <summary>
    /// Resetea el estado de la portada para permitir que se muestre nuevamente.
    /// </summary>
    public void ResetPortadaState()
    {
        portadaMostrada = false;
    }
}
