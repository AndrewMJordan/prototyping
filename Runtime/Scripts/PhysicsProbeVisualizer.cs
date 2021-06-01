/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech.Prototyping
{

    public class PhysicsProbeVisualizer : MonoBehaviour
    {
        [SerializeField]
        private PhysicsProbe probe;
        [SerializeField]
        private Color color = Color.red;

        private ITransformProbe TransformProbe => probe as ITransformProbe;
        private IOrientationProbe OrientationProbe => probe as IOrientationProbe;
        private IBodyProbe BodyProbe => probe as IBodyProbe;

        #region MONOBEHAVIOUR
        void LateUpdate()
        {
            Vector3 velocity;
            Vector3 position = TransformProbe.Position;
            velocity = BodyProbe.Velocity;

            Debug.DrawRay(position, velocity, color);

            Quaternion orientation = OrientationProbe.Orientation;
            Debug.DrawRay(position, orientation * Vector3.right, Color.red);
            Debug.DrawRay(position, orientation * Vector3.up, Color.green);
            Debug.DrawRay(position, orientation * Vector3.forward, Color.blue);
        }
        #endregion
    }
}
