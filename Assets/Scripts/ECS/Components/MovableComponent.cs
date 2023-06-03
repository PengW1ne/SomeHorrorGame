using System;
using Leopotam.Ecs;
using UnityEngine;

namespace PATROL
{
    [Serializable]
    public struct MovableComponent
    {
        public float Speed;
        [HideInInspector]public Vector3 Velocity;
    }
}