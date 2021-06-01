using UnityEngine;

namespace Andtech.Prototyping
{

    public static class StandardInput
    {

        public static Vector3 GetTranslationInput()
        {
            return new Vector3
            {
                x = GetAxis(KeyCode.A, KeyCode.D),
                y = GetAxis(KeyCode.Q, KeyCode.E),
                z = GetAxis(KeyCode.S, KeyCode.W)
            };

            float GetAxis(KeyCode negativeKey, KeyCode positiveKey)
            {
                if (Input.GetKey(negativeKey))
                    return -1.0f;

                if (Input.GetKey(positiveKey))
                    return 1.0f;

                return 0.0f;
            }
        }

        public static Vector3 GetRotationInput()
        {
            return new Vector3
            {
                x = Input.GetAxis("Mouse X"),
                y = Input.GetAxis("Mouse Y"),
                z = 0.0f
            };
        }

        public static float ClampAngle(float angle, float min, float max)
        {
            float start = (min + max) * 0.5f - 180;
            float floor = Mathf.FloorToInt((angle - start) / 360) * 360;
            min += floor;
            max += floor;
            return Mathf.Clamp(angle, min, max);
        }
    }
}