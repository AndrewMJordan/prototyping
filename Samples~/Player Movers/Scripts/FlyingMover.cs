/*
 *	Copyright (c) 2020, AndrewMJordan
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

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
