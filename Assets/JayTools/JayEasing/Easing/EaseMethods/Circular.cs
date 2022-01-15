using System;
using JayTools.JayEasing.Easing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.Easing.EaseMethods
{
    [Serializable]
    public class Circular : IEasing
    {
        public float Get(float time)
        {
            return 1f - Mathf.Sqrt(1f - time * time);
        }
    }
}