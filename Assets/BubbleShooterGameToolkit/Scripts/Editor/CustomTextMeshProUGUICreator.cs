using com.kshkum.ShootGame.Scripts.CommonUI;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Editor
{
    public static class CustomTextMeshProUGUICreator
    {
        [MenuItem("GameObject/UI/Custom TMP UGUI", false, 10)]
        public static void CreateCustomTextMeshProUGUI()
        {
            GameObject newObject = new GameObject("Default Name");
            CustomTextMeshProUGUI customText = newObject.AddComponent<CustomTextMeshProUGUI>();

            customText.fontSize = 32;
            customText.enableAutoSizing = true;
            customText.fontSizeMin = 16;
            customText.fontSizeMax = 200;
            customText.alignment = TextAlignmentOptions.Center;

            // Parent the new object to the currently selected object
            if (Selection.activeGameObject)
            {
                newObject.transform.SetParent(Selection.activeGameObject.transform, false);
            }
            else
            {
                // If no object is selected, but there's a canvas, parent it to the canvas
                Canvas parentCanvas = GameObject.FindObjectOfType<Canvas>();
                if (parentCanvas)
                {
                    newObject.transform.SetParent(parentCanvas.transform, false);
                }
            }

            // Ensure it's selected
            Selection.activeObject = newObject;
        }
    }
}