using JayTools.JayEasing.Easing.Definitions;
using JayTools.JayEasing.Easing.EaseMethods;
using JayTools.JayEasing.ScriptableEasing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.ScriptableEasing.Implementation
{
    [CreateAssetMenu(fileName = "Constant", menuName = "Tweeny/ScriptableEasing/Constant", order = 0)]
    public class ScriptableConstant: ScriptableEase
    {
        [Range(0f,1f)]
        public float Constant = 1;
        
        public override void Init()
        {
            Ease = new Ease(new Constant(Constant));
        }
    }
}