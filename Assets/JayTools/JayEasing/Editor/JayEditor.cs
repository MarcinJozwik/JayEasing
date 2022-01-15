using System;
using System.Collections.Generic;
using System.Linq;
using JayTools.JayEasing.Editor.VisualPreview;
using JayTools.JayEasing.ScriptableEasing.Definitions;
using UnityEngine;

namespace JayTools.JayEasing.Editor
{
    public static partial class JayEditor
    {
        public static AnimationCurve GetEasePreview(ScriptableEase ease, int samples = 10000, bool normalization = true)
        {
            return AnimationCurveEasePreview.GetPreview(ease.GetEase(), samples, normalization);
        }

        public static GraphView GetEasePreview(ScriptableEase ease, int samples = 10000)
        {
            GraphView graphView = new GraphView();

            graphView.AddLayer(new GraphLayer()
            {
                Frames = ease.GetEase().ToFramesArray((uint) samples),
                PointerColor = Color.cyan,
            });

            return graphView;
        }

        public static AnimationCurve GetCurveDistributionPreview(Func<float> function, int samples = 10000, int precision = 2)
        {
            List<float> normalList = new List<float>();
            List<int> countList = new List<int>();
            for (int i = 0; i < samples; i++)
            {
                float normal = function();
                decimal normalDecimal = (decimal) normal;
                normalDecimal = Decimal.Round(normalDecimal, precision);
                normal = (float) normalDecimal;

                if (normalList.Contains(normal))
                {
                    countList[normalList.IndexOf(normal)]++;
                }
                else
                {
                    normalList.Add(normal);
                    countList.Add(1);
                }
            }

            AnimationCurve curve = new AnimationCurve();
            for (var i = 0; i < normalList.Count; i++)
            {
                curve.AddKey(normalList[i], countList[i]);
            }

            return curve;
        }

        /// <summary>
        /// Runs the function samples times, counts the same results with given precision, sorts
        /// and normalizes the results and saves them as Graph Layer in CustomEasePreview.
        /// Not fast at all.
        /// </summary>
        /// <param name="function"></param>
        /// <param name="samples"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public static GraphView GetCustomDistributionPreview(Func<float> function, int samples = 10000, int precision = 2)
        {
            SortedList<float, float> sortedList = new SortedList<float, float>();
            for (int i = 0; i < samples; i++)
            {
                float functionValue = function();
                decimal decimalValue = (decimal) functionValue;
                decimalValue = Decimal.Round(decimalValue, precision);
                functionValue = (float) decimalValue;

                if (sortedList.ContainsKey(functionValue))
                {
                    sortedList[functionValue]++;
                }
                else
                {
                    sortedList.Add(functionValue, 1);
                }
            }

            float minTime = Single.PositiveInfinity;
            float maxTime = Single.NegativeInfinity;

            float minValue = Single.PositiveInfinity;
            float maxValue = Single.NegativeInfinity;

            for (var i = 0; i < sortedList.Count; i++)
            {
                float time = sortedList.Keys[i];
                if (time < minTime)
                {
                    minTime = time;
                }
                else if (time > maxTime)
                {
                    maxTime = time;
                }

                float value = sortedList.Values[i];
                if (value < minValue)
                {
                    minValue = value;
                }
                else if (value > maxValue)
                {
                    maxValue = value;
                }
            }

            List<float> timeList = new List<float>();
            List<float> valueList = new List<float>();

            timeList = sortedList.Keys.ToList();
            valueList = sortedList.Values.ToList();

            for (var i = 0; i < sortedList.Count; i++)
            {
                valueList[i] = (valueList[i] - minValue) / (maxValue - minValue);
                timeList[i] = (timeList[i] - minTime) / (maxTime - minTime);
            }


            KeyFrame[] frames = new KeyFrame[sortedList.Count];
            for (var i = 0; i < sortedList.Count; i++)
            {
                float normal = timeList[i];
                if (normal > 1 || normal < 0)
                {
                    Debug.LogError($"Time out of boundaries: {normal}");
                }

                float value = valueList[i];
                if (value > 1 || value < 0)
                {
                    Debug.LogError($"Value out of boundaries: {value}");
                }

                frames[i] = new KeyFrame(timeList[i], valueList[i]);
            }

            GraphView graphView = new GraphView();
            graphView.AddLayer(new GraphLayer()
            {
                Frames = frames,
                PointerColor = Color.cyan,
            });

            return graphView;
        }
    }
}