using System;
using JayTools.JayEasing.Easing.Definitions;

namespace JayTools.JayEasing.Easing.EaseMethods
{
    [Serializable]
    public class Arch : IEasing
    {
        public float Get(float time)
        {
            return new Scale(EaseMode.Flip).Get(time);
        }
    }
}