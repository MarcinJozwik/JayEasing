using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JayTools.JayEasing.Easing.Definitions;
using JayTools.JayEasing.Editor.VisualPreview;
using UnityEditor;
using UnityEngine;

namespace JayTools.JayEasing.Editor.Windows
{
    public class JayEasingPreviewWindow : EditorWindow
    {
        #region Fields

        private int samples = 100;
        private bool normalization = true;
        
        private AnimationCurve curve;
        private Ease ease;
        private List<KeyFrame> keyFrames = new List<KeyFrame>();
        
        private FieldInfo[] fields;
        private string[] fieldNames;
        private int index = -1;

        #endregion

        #region GUI

        [MenuItem(itemName: "Ease Preview", menuItem = "Tools/JayTools/JayEasing")]
        public static void ShowWindow()
        {
            var window = GetWindow<JayEasingPreviewWindow>(typeof(SceneView));
            window.titleContent = new GUIContent("Jay Ease Preview");
            window.Show();
        }

        private void OnEnable()
        {
            UpdateFields();
        }

        private void OnGUI()
        {
            HandleInput();
            
            EditorGUI.BeginChangeCheck();
            
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Settings", EditorStyles.boldLabel);
            samples = EditorGUILayout.IntField("Samples", samples);
            normalization = EditorGUILayout.Toggle("Normalization", normalization);
            EditorGUILayout.Space();
            
            EditorGUILayout.LabelField("Preview", EditorStyles.boldLabel);
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            EditorGUILayout.CurveField(curve, Color.cyan, new Rect(0,0,1,1), GUILayout.MinHeight(300), GUILayout.Width(400));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            EditorGUILayout.Space();

            index = EditorGUILayout.Popup("Ease Methods", index, fieldNames);
            
            if (EditorGUI.EndChangeCheck())
            {
                if (index >= 0)
                {
                    Preview();
                }
            }
        }
        
        #endregion

        #region Utilities

        private void HandleInput()
        {
            Event e = Event.current;
            if (e.type == EventType.KeyDown)
            {
                if (e.keyCode == KeyCode.DownArrow)
                {
                    if (index + 1 < fields.Length)
                    {
                        index++;
                        Preview();
                        Repaint();
                    }
                }

                if (e.keyCode == KeyCode.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        Preview();
                        Repaint();
                    }
                }
            }
        }
        private void Preview()
        {
            var field = fields[index];
            Ease ease = (Ease)(field.GetValue(null));
            this.ease = ease;
            curve = AnimationCurveEasePreview.GetPreview(ease, samples, normalization);
        }

        private void UpdateFields()
        {
            fields = typeof(EaseMode).GetFields(BindingFlags.Public | BindingFlags.Static);
            fieldNames = fields.Select(f => f.Name).ToArray();
        }

        #endregion

        #region Evaluation
        

        #endregion
    }
}