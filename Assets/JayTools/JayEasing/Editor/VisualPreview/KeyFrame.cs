namespace JayTools.JayEasing.Editor.VisualPreview
{
    public struct KeyFrame
    {
        public float Time;
        public float Value;

        public KeyFrame(float time, float value)
        {
            Time = time;
            Value = value;
        }
    }
}