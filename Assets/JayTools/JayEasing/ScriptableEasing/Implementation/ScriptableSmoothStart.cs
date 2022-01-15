using JayTools.JayEasing.Easing.Definitions;
using JayTools.JayEasing.Easing.EaseMethods;
using JayTools.JayEasing.ScriptableEasing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.ScriptableEasing.Implementation
{
    [CreateAssetMenu(fileName = "SmoothStart", menuName = "Tweeny/ScriptableEasing/SmoothStart", order = 0)]
    public class ScriptableSmoothStart : ScriptableEase
    {
        public uint Power = 2;
        
        public override void Init()
        {
            Ease = new Ease(new SmoothStart(Power));
        }
    }
}