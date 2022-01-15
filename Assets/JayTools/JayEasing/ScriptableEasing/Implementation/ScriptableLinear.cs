using JayTools.JayEasing.Easing.Definitions;
using JayTools.JayEasing.Easing.EaseMethods;
using JayTools.JayEasing.ScriptableEasing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.ScriptableEasing.Implementation
{
    [CreateAssetMenu(fileName = "Linear", menuName = "Tweeny/ScriptableEasing/Linear", order = 0)]
    public class ScriptableLinear : ScriptableEase
    {
        public override void Init()
        {
            Ease = new Ease(new Linear());
        }
    }
}