/*
 *	Copyright (c) 2020, AndrewMJordan
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech.Prototyping {

	public class Quitter : MonoBehaviour {

		#region MONOBEHAVIOUR
		protected virtual void Update() {
			if (Input.GetKeyDown(KeyCode.Escape)) {
				Application.Quit();
			}
		}
		#endregion
	}
}
