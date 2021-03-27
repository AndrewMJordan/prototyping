/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech.Prototyping {

	public class FPSMover : Mover {
		[SerializeField]
		private CharacterController controller;
		[SerializeField]
		private Rigidbody rigidbody;
		[SerializeField]
		private float jumpForce = 85.0F;

		protected override Vector3 ComputeTranslationVelocity() {
			var input = StandardInput.GetTranslationInput();
			bool wantsToJump = Input.GetKeyDown(KeyCode.Space);

			var basis = GetBasis();
			var velocity = controller.velocity;
			velocity += Physics.gravity * Time.deltaTime;

			var verticalVelocity = controller.isGrounded ? Vector3.zero : Vector3.Project(velocity, Physics.gravity);
			var planarVelocity = Vector3.ProjectOnPlane(velocity, Physics.gravity);
			var desiredVelocity = Speed * (basis * input);
			planarVelocity = Vector3.MoveTowards(planarVelocity, desiredVelocity, Acceleration * Time.deltaTime);
			planarVelocity = Vector3.ClampMagnitude(planarVelocity, Speed);
			if (wantsToJump) {
				verticalVelocity.y = jumpForce;
			}

			velocity = planarVelocity + verticalVelocity;

			return velocity;

			Quaternion GetBasis() => Quaternion.LookRotation(Vector3.ProjectOnPlane(PitchAnchor.forward, Vector3.up));
		}

		protected override void ApplyTranslation(Vector3 velocity) {
			controller.Move(velocity * Time.deltaTime);
		}

		protected override Vector3 GetCurrentVelocity() => controller.velocity;
	}
}
