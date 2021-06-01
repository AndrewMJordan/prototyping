using System;
using UnityEngine;
using UnityEngine.Events;

namespace Andtech.Prototyping
{

    public class UnityInitializer : MonoBehaviour
    {
        /// <summary>
        /// How should the initializer be invoked?
        /// </summary>
        [Tooltip("How should the initializer be invoked?")]
        public InitializationMode initializationMode = InitializationMode.Start;
        /// <summary>
        /// List of initialization methods.
        /// </summary>
        [Tooltip("List of initialization methods.")]
        public UnityEvent onInitialize;

        public void Initialize()
        {
            try
            {
                onInitialize.Invoke();
            }
            catch (Exception ex)
            {
                Debug.LogFormat(gameObject, "Initializer failed {0}", ex.Message);
            }
        }

        #region MONOBEHAVIOUR
        protected virtual void Awake()
        {
            if (initializationMode == InitializationMode.Awake)
                Initialize();
        }

        protected virtual void Start()
        {
            if (initializationMode == InitializationMode.Start)
                Initialize();
        }
        #endregion
    }
}
