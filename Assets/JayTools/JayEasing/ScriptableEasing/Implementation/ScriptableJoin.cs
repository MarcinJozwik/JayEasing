using JayTools.JayEasing.Easing.Definitions;
using JayTools.JayEasing.Easing.EaseMethods;
using JayTools.JayEasing.ScriptableEasing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.ScriptableEasing.Implementation
{
    [CreateAssetMenu(fileName = "Join", menuName = "Tweeny/ScriptableEasing/Join", order = 0)]
    public class ScriptableJoin : ScriptableEase
    {
        public ScriptableEase EaseA;
        public ScriptableEase EaseB;
        [Range(0f, 1f)] 
        public float TimeRatio = 0.5f;
        [Range(0f, 1f)] 
        public float ValueRatio = 0.5f;

        public override void Init()
        {
            Ease = new Ease(new Join(EaseA.GetEase(), EaseB.GetEase(), TimeRatio, ValueRatio));
        }
    }
}