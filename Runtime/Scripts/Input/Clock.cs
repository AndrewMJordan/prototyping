/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Andtech.Prototyping {

	public class Clock : MonoBehaviour {
		public float Interval => interval;

		[SerializeField]
		private float interval = 1.0F;

		public UnityEvent onTrigger;

		#region MONOBEHAVIOUR
		protected virtual void OnEnable() {
			var routine = Checking();
			StartCoroutine(routine);

			IEnumerator Checking() {
				while (enabled) {
					onTrigger.Invoke();

					yield return new WaitForSeconds(Interval);
				}
			}
		}
		#endregion
	}
}
