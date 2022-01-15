using System;
using JayTools.JayEasing.Easing.Definitions;

namespace JayTools.JayEasing.Easing.EaseMethods
{
    [Serializable]
    public class Bounce : IEasing
    {
        private readonly Ease ease;

        public Bounce(Ease ease)
        {
            this.ease = ease;
        }

        public float Get(float time)
        {
            float value = ease.Get(time);
            
            if (value < 0f)
            {
                return -value;
            }

            if (value > 1f)
            {
                return 1f - (value - 1f);
            }

            return value;
        }
    }
}