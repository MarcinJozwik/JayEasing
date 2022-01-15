using System;
using JayTools.JayEasing.Easing.Definitions;

namespace JayTools.JayEasing.Easing.EaseMethods
{
    [Serializable]
    public class Flip : IEasing
    {
        private readonly Ease ease;

        public Flip(Ease ease)
        {
            this.ease = ease;
        }

        public float Get(float time)
        {
            return 1 - ease.Get(time);
        }
    }
}