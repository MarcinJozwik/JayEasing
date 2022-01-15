using JayTools.JayEasing.Easing.Definitions;
using JayTools.JayEasing.Easing.EaseMethods;
using JayTools.JayEasing.ScriptableEasing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.ScriptableEasing.Implementation
{
    [CreateAssetMenu(fileName = "Mirror", menuName = "Tweeny/ScriptableEasing/Mirror", order = 0)]
    public class ScriptableMirror : ScriptableEase
    {
        public ScriptableEase EaseToMirror;

        public override void Init()
        {
            Ease = new Ease(new Mirror(EaseToMirror.GetEase()));
        }
    }
}