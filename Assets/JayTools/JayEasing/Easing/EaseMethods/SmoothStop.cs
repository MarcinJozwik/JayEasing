﻿using System;
using JayTools.JayEasing.Easing.Definitions;

namespace JayTools.JayEasing.Easing.EaseMethods
{
    [Serializable]
    public class SmoothStop : IEasing
    {
        private readonly Ease smoothStart;
        public SmoothStop(Ease smoothStart)
        {
            this.smoothStart = smoothStart;
        }

        public float Get(float time)
        {
            float value = time;
            value = EaseMode.Flip.Get(value);
            value = smoothStart.Get(value);
            value = EaseMode.Flip.Get(value);
            return value;
        }
    }
}