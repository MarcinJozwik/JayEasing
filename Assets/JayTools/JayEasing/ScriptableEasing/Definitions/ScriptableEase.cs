using JayTools.JayEasing.Easing.Definitions;

namespace JayTools.JayEasing.ScriptableEasing.Definitions
{ 
    public abstract class ScriptableEase : UnityEngine.ScriptableObject
    {
        protected Ease Ease;

        public abstract void Init();
        
        public virtual Ease GetEase()
        {
            Init();
            return Ease;
        }
    }
}