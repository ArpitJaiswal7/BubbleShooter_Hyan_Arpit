// // ©2015 - 2024 Candy Smith
 










using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace BubbleShooterGameToolkit.Scripts.Settings.Editor
{
    [CustomEditor(typeof(GameplaySettings))]
    public class GamePlaySettingsEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();
            var so = serializedObject;
            var prop = serializedObject.GetIterator();
            if (prop.NextVisible(true))
            {
                do
                {
                    var field = new PropertyField(prop);
 
                    if (prop.name == "m_Script")
                    {
                        field.SetEnabled(false);
                    }
                    field.Bind(so);
                    root.Add(field);
                }
                while (prop.NextVisible(false));
            }


            return root;
        }
    }
}