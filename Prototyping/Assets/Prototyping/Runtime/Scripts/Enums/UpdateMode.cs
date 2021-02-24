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
