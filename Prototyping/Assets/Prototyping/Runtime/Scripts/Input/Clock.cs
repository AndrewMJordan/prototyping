using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Andtech.Prototyping
{

    public class Clock : MonoBehaviour
    {
        public float Interval => interval;

        [SerializeField]
        private float interval = 1.0f;

        public UnityEvent onTrigger;

        #region MONOBEHAVIOUR
        protected virtual void OnEnable()
        {
            var routine = Checking();
            StartCoroutine(routine);

            IEnumerator Checking()
            {
                while (enabled)
                {
                    onTrigger.Invoke();

                    yield return new WaitForSeconds(Interval);
                }
            }
        }
        #endregion
    }
}
