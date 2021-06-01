using System;
using UnityEngine;
using UnityEngine.Events;

namespace Andtech.Prototyping
{
    [Serializable]
    public class ColliderEvent : UnityEvent<Collider> { }

    [RequireComponent(typeof(Collider))]
    public class ColliderTrigger : MonoBehaviour
    {
        public ColliderEvent TriggerEnter;
        public ColliderEvent TriggerStay;
        public ColliderEvent TriggerExit;

        private void OnTriggerEnter(Collider other)
        {
            TriggerEnter.Invoke(other);
        }

        private void OnTriggerStay(Collider other)
        {
            TriggerStay.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            TriggerExit.Invoke(other);
        }
    }
}
