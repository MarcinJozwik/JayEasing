using JayTools.JayEasing.Easing.Definitions;
using JayTools.JayEasing.Easing.EaseMethods;
using JayTools.JayEasing.ScriptableEasing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.ScriptableEasing.Implementation
{
    [CreateAssetMenu(fileName = "Elastic", menuName = "Tweeny/ScriptableEasing/Elastic", order = 0)]
    public class ScriptableElastic : ScriptableEase
    {
        public override void Init()
        {
            Ease = new Ease(new Elastic());
        }
    }
}