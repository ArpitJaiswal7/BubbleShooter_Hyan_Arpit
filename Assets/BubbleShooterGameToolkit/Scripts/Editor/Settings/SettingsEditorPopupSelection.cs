
 










using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

namespace com.kshkum.ShootGame.Scripts.Settings.Editor
{
    [CustomEditor(typeof(SettingsBase), true)]
    public class SettingsEditorPopupSelection : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var attributePath = (EditPrefab)Attribute.GetCustomAttribute(target.GetType(), typeof(EditPrefab));

            if (attributePath != null)
            {
                var root = new VisualElement();

                var popupPath = attributePath.PopupPath;

                var button = new Button(() =>
                {
                    var asset = AssetDatabase.LoadMainAssetAtPath(popupPath);
                    if (asset != null)
                    {
                        PrefabStageUtility.OpenPrefab(AssetDatabase.GetAssetPath(asset));
                    }
                    else
                    {
                        Debug.LogError($"No asset found at path '{popupPath}'");
                    }
                })
                {
                    text = "Edit popup"
                };

                root.Add(new IMGUIContainer(() => { DrawDefaultInspector(); }));
                root.Add(button);

                return root;
            }

            // Draw default inspector if no ShowInCustomInspectorAttribute is found.
            return new IMGUIContainer(() => { DrawDefaultInspector(); });
        }
    }
    
    [AttributeUsage(AttributeTargets.Class)]
    public class EditPrefab : Attribute
    {
        public string PopupPath { get; }

        public EditPrefab(string popupPath)
        {
            PopupPath = popupPath;
        }
    }
    
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class HelpBoxAttribute : PropertyAttribute
    {
        public string HelpText;
        public HelpBoxMessageType messageType;

        public HelpBoxAttribute(string helpText, HelpBoxMessageType messageType = HelpBoxMessageType.None)
        {
            this.HelpText = helpText;
            this.messageType = messageType;
        }
    }
}