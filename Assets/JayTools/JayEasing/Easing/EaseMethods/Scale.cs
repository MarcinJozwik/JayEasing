using System;
using JayTools.JayEasing.Easing.Definitions;

namespace JayTools.JayEasing.Easing.EaseMethods
{
    [Serializable]
    public class Scale : IEasing
    {
        private readonly Ease ease;

        public Scale(Ease ease)
        {
            this.ease = ease;
        }

        public float Get(float time)
        {
            return ease.Get(time) * time;
        }

    }
}