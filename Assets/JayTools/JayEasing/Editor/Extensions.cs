using JayTools.JayEasing.Easing.Definitions;
using JayTools.JayEasing.Editor.VisualPreview;

namespace JayTools.JayEasing.Editor
{
    public static class Extensions
    {
        public static KeyFrame[] ToFramesArray(this Ease ease, uint samples)
        {
            var frames = new KeyFrame[samples];
            
            for (int i = 0; i < samples; i++)
            {
                float time = i /(float)samples;
                float value = ease.Get(time);
                frames[i] = new KeyFrame(time, value);
            }

            return frames;
        }
    }
}