/*
 *	Copyright (c) 2020, AndrewMJordan
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

namespace Andtech.Prototyping {

	public interface IHighlightObserver {

		void OnHighlight();

		void OnDehighlight();
	}
}
