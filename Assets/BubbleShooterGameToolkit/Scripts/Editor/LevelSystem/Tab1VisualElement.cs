
 










using System;
using System.Collections.Generic;
using System.Linq;
using com.kshkum.ShootGame.Scripts.LevelSystem;
using com.kshkum.ShootGame.Scripts.Settings;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace com.kshkum.ShootGame.Scripts.Editor.LevelSystem
{
    public class Tab1VisualElement : VisualElement
    {
        private readonly SerializedObject levelSerializedObject;
        private LevelEditor levelEditor;
        private readonly Level level;
        private int prevSizeY;
        private Color[] ballColors;

        public Tab1VisualElement(SerializedObject levelSerializedObject, Level level, LevelEditor levelEditor)
        {
            this.levelEditor = levelEditor;
            this.levelSerializedObject = levelSerializedObject;
            this.level = level;
            ballColors = Resources.Load<GameplaySettings>("Settings/GameplaySettings").ballColors;
            AddToClassList("tab1-visual-element");
            DrawTab1(AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/com.kshkum.ShootGame/UIBuilder/GeneralEditor.uxml").CloneTree());
        }

        private void DrawTab1(TemplateContainer visualTree)
        {
            this.Clear();

            visualTree.Q<EnumField>("LevelType").RegisterCallback<ChangeEvent<Enum>>(evt =>
            {
                if(!Equals(evt.newValue, evt.previousValue))
                    levelEditor.tab2VisualElement.Reload();
            });

            visualTree.Q<IntegerField>("SizeY").RegisterCallback<KeyDownEvent>(evt =>
            {
                if (evt.keyCode == KeyCode.Return || evt.keyCode == KeyCode.KeypadEnter)
                {
                    var blocksLength = level.Length + (level.sizeY - prevSizeY) * level.sizeX;
                    level.Resize(blocksLength);
                    levelEditor.ReloadField();
                }
            });
            var star1 = visualTree.Q<IntegerField>("Star1");
            var star2 = visualTree.Q<IntegerField>("Star2");
            var star3 = visualTree.Q<IntegerField>("Star3");
            star1.bindingPath = "stars.Array.data[0]";
            star2.bindingPath = "stars.Array.data[1]";
            star3.bindingPath = "stars.Array.data[2]";
            star1.RegisterCallback<KeyDownEvent>(evt =>
            {
                if (evt.keyCode == KeyCode.Return || evt.keyCode == KeyCode.KeypadEnter)
                {
                    if (star1.value < 0)
                        star1.value = 0;
                    if (star2.value < star1.value)
                        star2.value = star1.value + 1;
                    if (star3.value < star2.value)
                        star3.value = star2.value + 1;
                }
            });
            star2.RegisterCallback<KeyDownEvent>(evt =>
            {
                if (evt.keyCode == KeyCode.Return || evt.keyCode == KeyCode.KeypadEnter)
                {
                    if (star2.value < star1.value)
                        star2.value = star1.value + 1;
                    if(star3.value < star2.value)
                        star3.value = star2.value + 1;
                }
            });
            star3.RegisterCallback<KeyDownEvent>(evt =>
            {
                if (evt.keyCode == KeyCode.Return || evt.keyCode == KeyCode.KeypadEnter)
                {
                    if(star3.value < star2.value)
                        star3.value = star2.value + 1;
                }
            });

            // create dropdown list based on the size of your serialized property array
            int arraySize = levelSerializedObject.FindProperty("randomBallColors").arraySize;
            List<int> indices = Enumerable.Range(0, arraySize).ToList();

            for (int i = 0; i < indices.Count; i++)
            {
                var boolField = visualTree.Q<BaseBoolField>($"rnd{i}");
                boolField.bindingPath = $"randomBallColors.Array.data[{i}]";
                var toggleElement = boolField.Q("unity-checkmark");
                toggleElement.style.unityBackgroundImageTintColor = ballColors[i];
            }
            
            this.Add(visualTree);
        }
    }
}