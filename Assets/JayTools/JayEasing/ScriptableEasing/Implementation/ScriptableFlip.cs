using JayTools.JayEasing.Easing.Definitions;
using JayTools.JayEasing.Easing.EaseMethods;
using JayTools.JayEasing.ScriptableEasing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.ScriptableEasing.Implementation
{
    [CreateAssetMenu(fileName = "Flip", menuName = "Tweeny/ScriptableEasing/Flip", order = 0)]
    public class ScriptableFlip : ScriptableEase
    {
        public ScriptableEase EaseToFlip;

        public override void Init()
        {
            Ease = new Ease(new Flip(EaseToFlip.GetEase()));
        }
    }
}