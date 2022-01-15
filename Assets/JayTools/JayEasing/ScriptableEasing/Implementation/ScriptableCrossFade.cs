using JayTools.JayEasing.Easing.Definitions;
using JayTools.JayEasing.Easing.EaseMethods;
using JayTools.JayEasing.ScriptableEasing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.ScriptableEasing.Implementation
{
    [CreateAssetMenu(fileName = "CrossFade", menuName = "Tweeny/ScriptableEasing/CrossFade", order = 0)]
    public class ScriptableCrossFade : ScriptableEase
    {
        public ScriptableEase EaseA;
        public ScriptableEase EaseB;

        public override void Init()
        {
            Ease = new Ease(new CrossFade(EaseA.GetEase(), EaseB.GetEase()));
        }
    }
}