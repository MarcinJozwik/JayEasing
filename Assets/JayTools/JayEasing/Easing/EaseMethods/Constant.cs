using System;
using JayTools.JayEasing.Easing.Definitions;

namespace JayTools.JayEasing.Easing.EaseMethods
{
    [Serializable]
    public class Constant : IEasing
    {
        private readonly float constant;

        public Constant(float constant)
        {
            this.constant = constant;
        }

        public float Get(float time)
        {
            return constant;
        }
    }
}