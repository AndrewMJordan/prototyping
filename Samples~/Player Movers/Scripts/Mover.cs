/*
 *	Copyright (c) 2020, AndrewMJordan
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech.Prototyping {

	public abstract class Mover : MonoBehaviour {
		public Transform PitchAnchor => pitchAnchor;
		public Transform YawAnchor => yawAnchor;
		public float Speed {
			get => speed;
			set => speed = value;
		}
		public float Acceleration {
			get => acceleration;
			set => acceleration = value;
		}

		[Header("Translation")]
		[SerializeField]
		private float speed = 6.0F;
		[SerializeField]
		private float acceleration = 12.0F;
		[Header("Rotation")]
		[SerializeField]
		private Transform yawAnchor;
		[SerializeField]
		private Transform pitchAnchor;
		[SerializeField]
		private float sensitivityX = 360.0F;
		[SerializeField]
		private float sensitivityY = 360.0F;
		[Range(-90.0F, 90.0F)]
		[SerializeField]
		private float pitchLimit = 85.0F;

		protected virtual void OnEnable() {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		protected virtual void OnDisable() {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		protected virtual void Update() {
			UpdateRotation();
			UpdateTranslation();
		}

		private void UpdateTranslation() {
			var velocity = ComputeTranslationVelocity();

			ApplyTranslation(velocity);
		}

		private void UpdateRotation() {
			var velocity = ComputeRotationVelocity();

			ApplyRotation(velocity);
		}

		protected virtual Vector3 ComputeTranslationVelocity() {
			var input = StandardInput.GetTranslationInput();
			var basis = GetBasis();
			var multiplier = Input.GetKey(KeyCode.LeftShift) ? 2.0F : 1.0F;
			var speed = Speed * multiplier;

			return speed * (basis * input);

			Quaternion GetBasis() => Quaternion.LookRotation(pitchAnchor.forward, pitchAnchor.up);
		}

		protected virtual Vector3 ComputeRotationVelocity() {
			var input = StandardInput.GetRotationInput();

			var velocity = new Vector3 {
				x = sensitivityX * input.x,
				y = sensitivityY * -input.y
			};

			return velocity;
		}

		protected abstract void ApplyTranslation(Vector3 velocity);

		protected abstract Vector3 GetCurrentVelocity();

		protected virtual void ApplyRotation(Vector3 velocity) {
			var yawEulerAngles = yawAnchor.eulerAngles;
			yawEulerAngles.y = yawEulerAngles.y + velocity.x * Time.unscaledDeltaTime;
			yawAnchor.eulerAngles = yawEulerAngles;

			var pitchEulerAngles = pitchAnchor.localEulerAngles;
			pitchEulerAngles.x = StandardInput.ClampAngle(pitchEulerAngles.x + velocity.y * Time.unscaledDeltaTime, -pitchLimit, pitchLimit);
			pitchAnchor.localEulerAngles = pitchEulerAngles;
		}
	}
}
