using UnityEngine;

namespace Andtech.Prototyping
{

    public class Quitter : MonoBehaviour
    {

        #region MONOBEHAVIOUR
        protected virtual void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
        #endregion
    }
}
