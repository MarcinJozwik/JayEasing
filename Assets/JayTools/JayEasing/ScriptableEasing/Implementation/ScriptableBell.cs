using JayTools.JayEasing.Easing.Definitions;
using JayTools.JayEasing.Easing.EaseMethods;
using JayTools.JayEasing.ScriptableEasing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.ScriptableEasing.Implementation
{
    [CreateAssetMenu(fileName = "Bell", menuName = "Tweeny/ScriptableEasing/Bell", order = 0)]
    public class ScriptableBell : ScriptableEase
    {
        public uint Power = 2;
        
        public override void Init()
        {
            Ease = new Ease(new Bell(Power));
        }
    }
}