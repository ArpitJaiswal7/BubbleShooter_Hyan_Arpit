
 










using System.Collections.Generic;
using System.Linq;
using com.kshkum.ShootGame.Scripts.Gameplay;
using com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects;
using com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects.Attachables.Labels;
using com.kshkum.ShootGame.Scripts.LevelSystem;
using com.kshkum.ShootGame.Scripts.Settings;
using com.kshkum.ShootGame.Scripts.Utils;
using UnityEditor;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Editor
{
    public static class EditorItemsLoader
    {
        public static List<LevelItemElement> GetItems()
        {
            // Load assets in the initial folder
            var editorIconsSettings = Resources.Load<EditorIconsSettings>("EditorSettings/EditorIcons");
            return LoadAssetsInFolder("Assets/com.kshkum.ShootGame/Prefabs/Balls/", editorIconsSettings);
        }

        static List<LevelItemElement> LoadAssetsInFolder(string folderPath, EditorIconsSettings editorIcons)
        {
            var itemButtons = new List<LevelItemElement>();
            string[] guids = AssetDatabase.FindAssets("", new[] { folderPath });
            Debug.Log("Guids : " + guids);
            foreach (string guid in guids)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var levelItemElement = AddAsset<Ball>(assetPath, editorIcons);
                if(!levelItemElement.IsEmpty)
                    itemButtons.Add(levelItemElement);
                var itemElement = AddAsset<Attachable>(assetPath, editorIcons);
                if(!itemElement.IsEmpty)
                    itemButtons.Add(itemElement);
            }

            return itemButtons;
        }
        
        private static LevelItemElement AddAsset<T>(string assetPath, EditorIconsSettings editorIconsSettings) where T : Component
        {
            LevelItemElement levelItemElement = default;

            var asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);
            if (asset != null)
            {
                // find icon for the asset
                Sprite editorIconSprite = editorIconsSettings.editorIcons.Where(editorIcon => editorIcon.prefab == asset.gameObject).Select(editorIcon => editorIcon.sprite).FirstOrDefault();
                if(editorIconSprite == null)
                {
                    var spriteStructs = asset.gameObject.GetSprites();
                    levelItemElement = new LevelItemElement(spriteStructs.ToArray(), asset.gameObject);
                }
                else
                {
                    Debug.Log("Asset is null" + asset.name);
                    levelItemElement = new LevelItemElement(null, asset.gameObject);
                    levelItemElement.sprite = editorIconSprite;
                }

            }
            return levelItemElement;
        }
    }
}