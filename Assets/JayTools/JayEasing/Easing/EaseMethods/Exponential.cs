using System;
using JayTools.JayEasing.Easing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.Easing.EaseMethods
{
    [Serializable]
    public class Exponential : IEasing
    {
        public float Get(float time)
        {
            return time == 0f? 0f : Mathf.Pow(1024f, time - 1f);
        }
    }
}