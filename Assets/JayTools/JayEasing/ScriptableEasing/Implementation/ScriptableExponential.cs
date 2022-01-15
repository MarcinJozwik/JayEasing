using JayTools.JayEasing.Easing.Definitions;
using JayTools.JayEasing.Easing.EaseMethods;
using JayTools.JayEasing.ScriptableEasing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.ScriptableEasing.Implementation
{
    [CreateAssetMenu(fileName = "Exponential", menuName = "Tweeny/ScriptableEasing/Exponential", order = 0)]
    public class ScriptableExponential : ScriptableEase
    {
        public override void Init()
        {
            Ease = new Ease(new Exponential());
        }
    }
}