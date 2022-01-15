using JayTools.JayEasing.Easing.Definitions;
using JayTools.JayEasing.ScriptableEasing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.ScriptableEasing.Implementation
{
    [CreateAssetMenu(fileName = "Arch", menuName = "Tweeny/ScriptableEasing/Arch", order = 0)]
    public class ScriptableArch : ScriptableEase
    {
        public override void Init()
        {
            Ease = EaseMode.Arch2;
        }
    }
}