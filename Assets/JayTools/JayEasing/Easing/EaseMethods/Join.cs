using System;
using JayTools.JayEasing.Easing.Definitions;

namespace JayTools.JayEasing.Easing.EaseMethods
{
    [Serializable]
    public class Join : IEasing
    {
        private readonly Ease getEaseA;
        private readonly Ease getEaseB;
        private readonly float timeRatio;
        private readonly float valueRatio;

        public Join(Ease easeA, Ease easeB, float timeRatio = 0.5f, float valueRatio = 0.5f)
        {
            this.getEaseA = easeA;
            this.getEaseB = easeB;
            this.timeRatio = timeRatio;
            this.valueRatio = valueRatio;
        }

        public float Get(float time)
        {
            if (time < timeRatio)
            {
                return getEaseA.Get(time * 1 / timeRatio) * valueRatio;
            }

            if (time == 1f && timeRatio == 1f)
            {
                return valueRatio;
            }

            return getEaseB.Get((time - timeRatio) * (1 / (1 - timeRatio))) * (1 - valueRatio) +
                   valueRatio;

            // if (time < 0.5f)
            // {
            //     return getEaseA.Get(time * 2f) * 0.5f;
            // }
            //
            // return getEaseB.Get(time * 2f - 1f) * 0.5f + 0.5f;
        }
    }
}