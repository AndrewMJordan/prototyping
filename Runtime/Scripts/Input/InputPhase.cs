/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System;

namespace Andtech.Prototyping {

	[Flags]
	public enum KeyPhase {
		None = 0,
		Down = 1 << 0,
		Pressed = 1 << 1,
		Up = 1 << 2,
		Unpressed = 1 << 3
	}
}
