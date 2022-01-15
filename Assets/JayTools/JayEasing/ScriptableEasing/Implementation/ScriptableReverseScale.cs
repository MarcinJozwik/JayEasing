using JayTools.JayEasing.Easing.Definitions;
using JayTools.JayEasing.Easing.EaseMethods;
using JayTools.JayEasing.ScriptableEasing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.ScriptableEasing.Implementation
{
    [CreateAssetMenu(fileName = "ReverseScale", menuName = "Tweeny/ScriptableEasing/ReverseScale", order = 0)]
    public class ScriptableReverseScale : ScriptableEase
    {
        private ScriptableEase ScriptableEase;
        public override void Init()
        {
            Ease = new Ease(new ReverseScale(ScriptableEase.GetEase()));
        }
    }
}