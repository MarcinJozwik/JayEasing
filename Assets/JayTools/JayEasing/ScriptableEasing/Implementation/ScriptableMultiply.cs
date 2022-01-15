using JayTools.JayEasing.Easing.Definitions;
using JayTools.JayEasing.Easing.EaseMethods;
using JayTools.JayEasing.ScriptableEasing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.ScriptableEasing.Implementation
{
    [CreateAssetMenu(fileName = "Multiply", menuName = "Tweeny/ScriptableEasing/Multiply", order = 0)]
    public class ScriptableMultiply : ScriptableEase
    {
        public ScriptableEase EaseA;
        public ScriptableEase EaseB;

        public override void Init()
        {
            Ease = new Ease(new Multiply(EaseA.GetEase(), EaseB.GetEase()));
        }
    }
}