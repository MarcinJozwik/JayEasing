using System;
using JayTools.JayEasing.Editor.VisualPreview;
using JayTools.JayEasing.ScriptableEasing.Definitions;
using UnityEditor;
using UnityEngine;

namespace JayTools.JayEasing.Editor.Windows
{
    [CustomEditor(typeof(ScriptableEase), true)]
    public class ScriptableEaseEditor : UnityEditor.Editor
    {
        private ScriptableEase ease;
        private AnimationCurve curve;
        private string message = String.Empty;

        private int samples = 100;
        private bool normalization = true;
        private bool foldout = false;
        private float slider = 0;
        private GraphView graphView;
        private bool showCustomPreview = true;
        private bool showAnimationCurvePreview = false;

        private void OnEnable()
        {
            ease = target as ScriptableEase;
            UpdatePreview();
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            
            base.OnInspectorGUI();
            
            EditorGUILayout.Separator();
            
            if (message != String.Empty)
            {
                EditorGUILayout.HelpBox(message, MessageType.Error);
            }
            
            EditorGUILayout.Separator();
            
            EditorGUILayout.LabelField("Preview:", EditorStyles.boldLabel);
            EditorGUILayout.Separator();

            if (showCustomPreview)
            {
                graphView?.Draw();
            
                slider = EditorGUILayout.Slider("Time:", slider, 0f, 1f);
                graphView?.UpdateValues(0, slider, ease.GetEase());
            }
            
            if (showAnimationCurvePreview)
            {
                EditorGUILayout.CurveField(curve, Color.cyan, new Rect(0,0,1,1), GUILayout.MinHeight(300), GUILayout.Width(400)); 
            }
            
            EditorGUILayout.Separator();
            foldout = EditorGUILayout.Foldout(foldout, "Preview settings");
            
            if (foldout)
            {
                samples = EditorGUILayout.IntField("Samples", samples);
                normalization = EditorGUILayout.Toggle("Normalization", normalization);
                showCustomPreview = EditorGUILayout.Toggle("Custom Preview", showCustomPreview);
                showAnimationCurvePreview = EditorGUILayout.Toggle("Animation Curve Preview", showAnimationCurvePreview);
            }
            
            if (EditorGUI.EndChangeCheck())
            {
                UpdatePreview();
            }
        }

        private void UpdatePreview()
        {
            try
            {
                curve = JayEditor.GetEasePreview(ease, samples, normalization);
                
                graphView?.Clear();
                graphView = JayEditor.GetEasePreview(ease, samples);
                
                message = String.Empty;
            }
            catch (Exception e)
            {
                curve = new AnimationCurve();
                message = "The definition of the Ease Method is incomplete. Are you missing a reference?";
            }
        }
    }
}