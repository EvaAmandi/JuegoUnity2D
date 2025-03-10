using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Clase que realiza el cambio de la escena final al menu, 
/// esperando unos segundos antes de producirse el cambio
/// </summary>
public class CambioEscenaFinal : MonoBehaviour
{
    public string nombreEscenaMenu = "MenuPrincipal";
    public float tiempoMostrarEnhorabuena = 5f;

    /// <summary>
    /// Inicia la corrutina de EsperarYCambiarAMenu
    /// </summary>
    void Start()
    {
      
        StartCoroutine(EsperarYCambiarAMenu());
    }

    /// <summary>
    /// Corrutina que espera unos segundos y cambia al menu
    /// </summary>
    /// <returns></returns>
    private IEnumerator EsperarYCambiarAMenu()
    {
        yield return new WaitForSecondsRealtime(tiempoMostrarEnhorabuena);
        CambiarAMenuPrincipal();
    }

    /// <summary>
    /// Método que cambia la escena al menu 
    /// </summary>
    private void CambiarAMenuPrincipal()
    {
        SceneManager.LoadScene(nombreEscenaMenu);
    }
}
