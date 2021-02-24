/*
 *	Copyright (c) 2020, AndrewMJordan
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System;

namespace Andtech.Prototyping {

	[Flags]
	public enum UpdateMode {
		Never,
		Update,
		LateUpdate,
		FixedUpdate
	}
}