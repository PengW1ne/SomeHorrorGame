using System;
using TMPro;
using UnityEngine;

namespace PATROL
{
    [Serializable]
    public struct ClockComponent
    {
        [HideInInspector] public float day;
        [HideInInspector] public float H;
        [HideInInspector] public float M;
        [HideInInspector] public float dayNormalized;
        public TextMeshProUGUI HourTextMeshProUGUI;
        public TextMeshProUGUI MinTextMeshProUGUI;
    }
}