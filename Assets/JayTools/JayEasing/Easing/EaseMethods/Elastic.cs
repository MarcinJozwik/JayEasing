using JayTools.JayEasing.Easing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.Easing.EaseMethods
{
    public class Elastic : IEasing
    {
        public float Get(float time)
        {
            if (time == 0)
            {
                return 0;
            }

            if (time == 1)
            {
                return 1;
            }
            
            return -Mathf.Pow(2f, 10f * (time -= 1f)) * Mathf.Sin((time - 0.1f) * (2f * Mathf.PI) / 0.4f);
        }
    }
}