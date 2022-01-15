using JayTools.JayEasing.Easing.Definitions;
using JayTools.JayEasing.Easing.EaseMethods;
using JayTools.JayEasing.ScriptableEasing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.ScriptableEasing.Implementation
{
    [CreateAssetMenu(fileName = "SmoothStop", menuName = "Tweeny/ScriptableEasing/SmoothStop", order = 0)]
    public class ScriptableSmoothStop : ScriptableEase
    {
        public ScriptableSmoothStart SmoothStart;
        
        public override void Init()
        {
            Ease = new Ease(new SmoothStop(SmoothStart.GetEase()));
        }
    }
}