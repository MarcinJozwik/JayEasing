using UnityEngine;

namespace JayTools.JayEasing.Editor.VisualPreview
{
    public class GraphLayer
    {
        public KeyFrame Pointer;
        public KeyFrame[] Frames;
        public Color GraphColor;
        public Color PointerColor;

        public GraphLayer()
        {
            Pointer = new KeyFrame();
            GraphColor = Color.cyan;
            PointerColor = Color.red;
        }
    }
}