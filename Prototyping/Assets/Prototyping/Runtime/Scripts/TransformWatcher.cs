using System;
using UnityEngine;
using UnityEngine.Events;

namespace Andtech.Prototyping {

	public class TransformWatcher : MonoBehaviour {
		public Transform Target {
			get => target;
			set => target = value;
		}

		[SerializeField]
		private Transform target;

		public UnityEvent onTransformChanged;

		public void Check() {
			if (Target.hasChanged) {
				ChangedTransform?.Invoke(this, EventArgs.Empty);
				onTransformChanged.Invoke();
				Target.hasChanged = false;
			}
		}

		#region EVENT
		public event EventHandler ChangedTransform;
		#endregion
	}
}
