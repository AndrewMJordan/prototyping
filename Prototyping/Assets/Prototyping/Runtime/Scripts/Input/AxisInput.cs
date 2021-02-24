using System;
using UnityEngine;
using UnityEngine.Events;

namespace Andtech.Prototyping {

	[Serializable]
	public class AxisInputEvent : UnityEvent<float> { }

	/// <summary>
	/// Invokes actions when a button is activated.
	/// </summary>
	public class AxisInput : MonoBehaviour {
		[SerializeField]
		private string axisName = "Fire1";

		public AxisInputEvent onTrigger;

		#region MONOBEHAVIOUR
		protected virtual void Update() {
			onTrigger?.Invoke(Input.GetAxis(axisName));
		}
		#endregion
	}
}
