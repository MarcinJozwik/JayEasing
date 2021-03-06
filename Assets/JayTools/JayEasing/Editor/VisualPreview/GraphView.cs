using System.Collections.Generic;
using JayTools.JayEasing.Easing.Definitions;
using UnityEditor;
using UnityEngine;

namespace JayTools.JayEasing.Editor.VisualPreview
{
    public class GraphView
    {
        private Material material;
        
        public Color BackgroundColor = Color.black;

        public bool ShowPointer = true;
        public bool ShowRawData = true;
        
        public int PointerSize = 5;
        
        private List<GraphLayer> graphLayers;

        private Rect rect;

        public GraphView()
        {
            Shader shader = Shader.Find("Hidden/Internal-Colored");
            material = new Material(shader);
            graphLayers = new List<GraphLayer>();
        }
        
        public void Clear()
        {
            GameObject.DestroyImmediate(material);
        }
        
        public void AddLayer(GraphLayer layer)
        {
            graphLayers.Add(layer);
        }

        public void UpdateValues(int layerIndex, float time, Ease ease)
        {
            var layer = graphLayers[layerIndex];
            layer.Pointer.Time = time;
            layer.Pointer.Value = ease.Get(time);
        }

        public void UpdateValues(int layerIndex, float time, float value)
        {
            var layer = graphLayers[layerIndex];
            layer.Pointer.Time = time;
            layer.Pointer.Value = value;
        }
        
        public void Draw()
        {
            // Begin to draw a horizontal layout, using the helpBox EditorStyle
            GUILayout.BeginHorizontal(EditorStyles.helpBox);

            // Reserve GUI space with a width from 10 to 10000, and a fixed height of 200, and 
            // cache it as a rectangle.
            rect = GUILayoutUtility.GetRect(10, 500, 200, 200);
            if (Event.current.type == EventType.Repaint)
            {
                // If we are currently in the Repaint event, begin to draw a clip of the size of 
                // previously reserved rectangle, and push the current matrix for drawing.
                GUI.BeginClip(rect);
                GL.PushMatrix();

                // Clear the current render buffer, setting a new background colour, and set our
                // material for rendering.
                GL.Clear(true, false, BackgroundColor);
                material.SetPass(0);
                
                DrawBackground();
                DrawGrid();
                DrawGraph();
                DrawPointer();

                GL.PopMatrix();
                GUI.EndClip();
            }

            GUILayout.EndHorizontal();
            DrawRawData();
        }

        private void DrawBackground()
        {
            // Start drawing in OpenGL Quads, to draw the background canvas. Set the
            // colour black as the current OpenGL drawing colour, and draw a quad covering
            // the dimensions of the layoutRectangle.
         
            GL.Begin(GL.QUADS);
            GL.Color(Color.black);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(rect.width, 0, 0);
            GL.Vertex3(rect.width, rect.height, 0);
            GL.Vertex3(0, rect.height, 0);
            GL.End();
        }

        private void DrawGrid()
        {
            // Start drawing in OpenGL Lines, to draw the lines of the grid.
            GL.Begin(GL.LINES);
                
            int count = (int)(rect.width / 10) + 20;

            for(int i = 0; i < count; i++)
            {
                // For every line being drawn in the grid, create a colour placeholder; if the
                // current index is divisible by 5, we are at a major segment line; set this
                // colour to a dark grey. If the current index is not divisible by 5, we are
                // at a minor segment line; set this colour to a lighter grey. Set the derived
                // colour as the current OpenGL drawing colour.
                Color lineColour = (i % 5 == 0 
                    ? new Color(0.5f, 0.5f, 0.5f) : new Color(0.2f, 0.2f, 0.2f));
                GL.Color(lineColour);

                // Derive a new x co-ordinate from the initial index, converting it straight
                // into line positions
                float x = i * 10;

                if (x >= 0 && x < rect.width)
                {
                    // If the current derived x position is within the bounds of the
                    // rectangle, draw another vertical line.
                    GL.Vertex3(x, 0, 0);
                    GL.Vertex3(x, rect.height, 0);
                }

                if (i < rect.height / 10)
                {
                    // Convert the current index value into a y position, and if it is within
                    // the bounds of the rectangle, draw another horizontal line.
                    GL.Vertex3(0, i * 10, 0);
                    GL.Vertex3(rect.width, i * 10, 0);
                }
            }
            // End lines drawing.
            GL.End();
        }

        private void DrawGraph()
        {
            GL.Begin(GL.LINES);

            for (int i = 0; i < graphLayers.Count; i++)
            {
                var layer = graphLayers[i];
                GL.Color(layer.GraphColor);
                int count = layer.Frames.Length;
                for (int j = 0; j < count; j++)
                {
                    var frame = layer.Frames[j];
                    //using inverted value because point (0,0) is in the upper left corner
                    GL.Vertex3(frame.Time * rect.width, (1 - frame.Value) * rect.height, 0);
                }
            }

            GL.End();
        }

        private void DrawPointer()
        {
            if (ShowPointer)
            {
                for (var i = 0; i < graphLayers.Count; i++)
                {
                    var layer = graphLayers[i];
                    float time = layer.Pointer.Time;
                    
                    //using inverted value because point (0,0) is in the upper left corner
                    float value = 1 - layer.Pointer.Value;
                    
                    GL.Begin(GL.QUADS);
                    GL.Color(layer.PointerColor);
                    GL.Vertex3(time * rect.width, value * rect.height - PointerSize, 0);
                    GL.Vertex3(time * rect.width + PointerSize, value * rect.height, 0);
                    GL.Vertex3(time * rect.width, value * rect.height + PointerSize, 0);
                    GL.Vertex3(time * rect.width - PointerSize, value * rect.height, 0);
                    GL.End();
                }
            }
        }

        private void DrawRawData()
        {
            if (ShowRawData)
            {
                for (var i = 0; i < graphLayers.Count; i++)
                {
                    var layer = graphLayers[i];
                    float time = layer.Pointer.Time;
                    float value = layer.Pointer.Value;
                    
                    EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
                    if (graphLayers.Count > 1)
                    {
                        EditorGUILayout.LabelField(i + ":", GUILayout.MaxWidth(25));
                    }
                    EditorGUILayout.LabelField("Current Value " + value);
                    EditorGUILayout.LabelField("Current Time " + time);
                    EditorGUILayout.EndHorizontal();
                }
            }
            
        }
    }
}