using UnityEngine;
using UnityEngine.Events;

namespace Andtech.Prototyping {

	public class Updater : MonoBehaviour {
		public UpdateMode UpdateMode => updateMode;

		[SerializeField]
		private UpdateMode updateMode = UpdateMode.Update;

		public UnityEvent onUpdate;

		#region MONOBEHAVIOUR
		protected virtual void Update() {
			if (updateMode.HasFlag(UpdateMode.Update))
				onUpdate.Invoke();
		}

		protected virtual void LateUpdate() {
			if (updateMode.HasFlag(UpdateMode.LateUpdate))
				onUpdate.Invoke();
		}

		protected virtual void FixedUpdate() {
			if (updateMode.HasFlag(UpdateMode.FixedUpdate))
				onUpdate.Invoke();
		}
		#endregion
	}
}
