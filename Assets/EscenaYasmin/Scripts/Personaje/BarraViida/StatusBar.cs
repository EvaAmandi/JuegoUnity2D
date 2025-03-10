using Unity.VisualScripting;
using UnityEngine;

namespace yasmin {
    /// <summary>
    /// Controla la visualización de la barra de vida.
    /// </summary>
    public class StatusBar : MonoBehaviour
    {
        private Movimiento movimiento;
        [SerializeField] Transform bar;

        /// <summary>
        /// Actualiza el estado visual de la barra.
        /// </summary>
        /// <param name="current">Valor actual del estado.</param>
        /// <param name="max">Valor máximo del estado.</param>
        public void SetState(int current, int max)
        {
            float state = (float)current;
            state /= max;
            if (state < 0f)
            {
                state = 0f;
                
            }
            bar.transform.localScale = new Vector3(state, 1, 1);
        }
    }
}
