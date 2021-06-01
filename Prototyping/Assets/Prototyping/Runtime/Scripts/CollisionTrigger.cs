using System;
using UnityEngine;
using UnityEngine.Events;

namespace Andtech.Prototyping
{
    [Serializable]
    public class CollisionEvent : UnityEvent<Collision> { }

    [RequireComponent(typeof(Collider))]
    public class CollisionTrigger : MonoBehaviour
    {
        public CollisionEvent CollisionEnter;
        public CollisionEvent CollisionStay;
        public CollisionEvent CollisionExit;

        private void OnCollisionEnter(Collision collision)
        {
            CollisionEnter.Invoke(collision);
        }

        private void OnCollisionStay(Collision collision)
        {
            CollisionStay.Invoke(collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            CollisionExit.Invoke(collision);
        }
    }
}