
 










using System.Collections.Generic;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Utils
{
    public static class TransformUtils
    {
        public static void SetParentPosition(this Transform mainTR, Vector3 v)
        {
            List<Transform> list = new List<Transform>();
            var parent = mainTR.parent;
            for (int i = parent.childCount - 1; i >= 0; --i)
            {
                Transform child = parent.GetChild(i);
                child.SetParent(parent.parent);
                list.Add(child);
            }
            parent.transform.position = v;
            
            foreach (Transform child in list)
            {
                child.SetParent(parent, true);
            }
        }
        
    }

    public static class TryAddComponent
    {
        public static T AddComponentIfNotExists<T>(this GameObject gameObject) where T : Component
        {
            if (!gameObject.TryGetComponent<T>(out var component))
            {
                component = gameObject.AddComponent<T>();
            }

            return component;
        }
    }
}