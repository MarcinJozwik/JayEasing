using JayTools.JayEasing.Easing.Definitions;
using JayTools.JayEasing.Easing.EaseMethods;
using JayTools.JayEasing.ScriptableEasing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.ScriptableEasing.Implementation
{
    [CreateAssetMenu(fileName = "Circular", menuName = "Tweeny/ScriptableEasing/Circular", order = 0)]
    public class ScriptableCircular : ScriptableEase
    {
        public override void Init()
        {
            Ease = new Ease(new Circular());
        }
    }
}