using JayTools.JayEasing.Easing.Definitions;
using JayTools.JayEasing.Easing.EaseMethods;
using JayTools.JayEasing.ScriptableEasing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.ScriptableEasing.Implementation
{
    [CreateAssetMenu(fileName = "Scale", menuName = "Tweeny/ScriptableEasing/Scale", order = 0)]
    public class ScriptableScale : ScriptableEase
    {
        private ScriptableEase ScriptableEase;
        public override void Init()
        {
            Ease = new Ease(new Scale(ScriptableEase.GetEase()));
        }
    }
}