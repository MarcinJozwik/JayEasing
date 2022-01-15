using JayTools.JayEasing.Easing.Definitions;
using JayTools.JayEasing.ScriptableEasing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.ScriptableEasing.Implementation
{
    [CreateAssetMenu(fileName = "Bezier", menuName = "Tweeny/ScriptableEasing/Bezier", order = 0)]
    public class ScriptableBezier : ScriptableEase
    {
        public override void Init()
        {
            Ease = EaseMode.Bezier;
        }
    }
}