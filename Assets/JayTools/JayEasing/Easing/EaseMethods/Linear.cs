using System;
using JayTools.JayEasing.Easing.Definitions;

namespace JayTools.JayEasing.Easing.EaseMethods
{
    [Serializable]
    public class Linear : IEasing
    {
        public float Get(float time)
        {
            return time;
        }
    }
}