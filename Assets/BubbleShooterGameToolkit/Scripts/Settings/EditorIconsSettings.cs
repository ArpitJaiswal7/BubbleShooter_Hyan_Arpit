
 










using System;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Settings
{
    public class EditorIconsSettings : ScriptableObject
    {
        public EditorIcon[] editorIcons;
    }
    
    [Serializable]
    public class EditorIcon
    {
        public GameObject prefab;
        public Sprite sprite;
    }
}