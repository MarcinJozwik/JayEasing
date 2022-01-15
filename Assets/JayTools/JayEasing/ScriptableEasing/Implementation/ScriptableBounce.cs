using JayTools.JayEasing.Easing.Definitions;
using JayTools.JayEasing.Easing.EaseMethods;
using JayTools.JayEasing.ScriptableEasing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.ScriptableEasing.Implementation
{
    [CreateAssetMenu(fileName = "Bounce", menuName = "Tweeny/ScriptableEasing/Bounce", order = 0)]
    public class ScriptableBounce : ScriptableEase
    {
        public ScriptableEase EaseToBounce;

        public override void Init()
        {
            Ease = new Ease(new Bounce(EaseToBounce.GetEase()));
        }
    }
}