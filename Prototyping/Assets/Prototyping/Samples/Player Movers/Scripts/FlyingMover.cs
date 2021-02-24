using UnityEngine;

namespace Andtech.Prototyping {

	public class FlyingMover : Mover {
		[SerializeField]
		private CharacterController controller;

		protected override void ApplyTranslation(Vector3 velocity) {
			controller.Move(velocity * Time.deltaTime);
		}

		protected override Vector3 GetCurrentVelocity() => controller.velocity;
	}
}
