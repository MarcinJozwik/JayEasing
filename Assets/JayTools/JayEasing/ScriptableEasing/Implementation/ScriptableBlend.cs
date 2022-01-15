using JayTools.JayEasing.Easing.Definitions;
using JayTools.JayEasing.Easing.EaseMethods;
using JayTools.JayEasing.ScriptableEasing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.ScriptableEasing.Implementation
{
    [CreateAssetMenu(fileName = "Blend", menuName = "Tweeny/ScriptableEasing/Blend", order = 0)]
    public class ScriptableBlend : ScriptableEase
    {
        public ScriptableEase EaseA;
        public ScriptableEase EaseB;
        
        [Range(0f, 1f)] 
        public float Blend;

        public override void Init()
        {
            Ease = new Ease(new Blend(EaseA.GetEase(), EaseB.GetEase(), Blend));
        }
    }
}