using System;
using UnityEngine;

namespace PATROL
{
    [Serializable]
    public struct CheckPointComponent
    {
        public float ActivationDistance;
        public Transform CheckPointPosition;
    }
}