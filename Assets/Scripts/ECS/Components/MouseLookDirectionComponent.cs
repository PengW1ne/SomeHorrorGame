using System;
using UnityEngine;

namespace PATROL
{
    [Serializable]
    public struct MouseLookDirectionComponent
    {
        public Transform PlayerCameraTransform;
        [HideInInspector] public Vector2 Direction;
        [Range(0, 2)] public float MouseSensitivity;
    }
}