using System;
using JayTools.JayEasing.Easing.Definitions;

namespace JayTools.JayEasing.Easing.EaseMethods
{
    [Serializable]
    public class Mirror : IEasing
    {
        private readonly Ease ease;

        public Mirror(Ease ease)
        {
            this.ease = ease;
        }

        public float Get(float time)
        {
            return ease.Get(1 - time);
        }
    }
}