using JayTools.JayEasing.Easing.Definitions;
using JayTools.JayEasing.ScriptableEasing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.ScriptableEasing.Implementation
{
    [CreateAssetMenu(fileName = "Bezier7", menuName = "Tweeny/ScriptableEasing/Bezier7", order = 0)]
    public class ScriptableBezier7 : ScriptableEase
    {
        public override void Init()
        {
            Ease = EaseMode.Bezier7;
        }
    }
}