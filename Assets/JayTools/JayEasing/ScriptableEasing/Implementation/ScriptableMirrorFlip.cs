using JayTools.JayEasing.Easing.Definitions;
using JayTools.JayEasing.Easing.EaseMethods;
using JayTools.JayEasing.ScriptableEasing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.ScriptableEasing.Implementation
{
    [CreateAssetMenu(fileName = "MirrorFlip", menuName = "Tweeny/ScriptableEasing/MirrorFlip", order = 0)]
    public class ScriptableMirrorFlip : ScriptableEase
    {
        public ScriptableEase EaseToMirrorFlip;

        public override void Init()
        {
            var flip = new Ease(new Flip(EaseToMirrorFlip.GetEase()));
            Ease = new Ease(new Mirror(flip));
        }
    }
}