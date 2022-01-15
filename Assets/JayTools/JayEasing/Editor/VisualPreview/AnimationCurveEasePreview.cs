using System.Collections.Generic;
using JayTools.JayEasing.Easing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.Editor.VisualPreview
{
    public class AnimationCurveEasePreview
    {
        private static List<KeyFrame> keyFrames;
        private static AnimationCurve curve;
        private static int samples;
        private static Ease ease;
        private static bool normalization;
        
        public static AnimationCurve GetPreview(Ease ease, int samples, bool normalization)
        {
            AnimationCurveEasePreview.samples = samples;
            AnimationCurveEasePreview.ease = ease;
            AnimationCurveEasePreview.normalization = normalization;
            
            Shape();
            return curve;
        }

        private static void Shape()
        {
            Evaluate();
            Normalize();
            Assign();
        }
    
        private static void Evaluate()
        {
            keyFrames = new List<KeyFrame>();
            int count = samples;
            for (int i = 0; i <= count; i++)
            {
                float time = i / (float) count;
                float value = ease.Get(time);
                keyFrames.Add(new KeyFrame(time, value));
            }
        }

        private static void Normalize()
        {
            if (!normalization)
            {
                return;
            }
        
            float min = GetMinValue();
            float max = GetMaxValue();
            
            for (var i = 0; i < keyFrames.Count; i++)
            {
                float value = (keyFrames[i].Value - min) / max;
                keyFrames[i] = new KeyFrame(keyFrames[i].Time, value);
            }
        }

        private static void Assign()
        {
            curve = new AnimationCurve();
            foreach (var keyFrame in keyFrames)
            {
                curve.AddKey(keyFrame.Time, keyFrame.Value);
            }
        }

        private static float GetMinValue()
        {
            float min = 1f;
            foreach (var keyFrame in keyFrames)
            {
                if (keyFrame.Value < min)
                {
                    min = keyFrame.Value;
                }
            }
            return min;
        }
    
        private static float GetMaxValue()
        {
            float max = 0f;
            foreach (var keyFrame in keyFrames)
            {
                if (keyFrame.Value > max)
                {
                    max = keyFrame.Value;
                }
            }
            return max;
        }
    }
}