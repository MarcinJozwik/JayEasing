using System;
using JayTools.JayEasing.Easing.Definitions;

namespace JayTools.JayEasing.Easing.EaseMethods
{
    [Serializable]
    public class ReverseScale : IEasing
    {
        private readonly Ease ease;

        public ReverseScale(Ease ease)
        {
            this.ease = ease;
        }

        public float Get(float time)
        {
            return ease.Get(time) * (1 - time);
        }

    }
}