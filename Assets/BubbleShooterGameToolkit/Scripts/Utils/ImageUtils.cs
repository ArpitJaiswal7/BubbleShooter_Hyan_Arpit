
 










using System.Collections.Generic;
using System.Linq;
using BubbleShooterGameToolkit.Scripts.LevelSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace BubbleShooterGameToolkit.Scripts.Utils
{
    public static class ImageUtils
    {
        public static VisualElement GetElementFromPrefab(this GameObject prefab, int size)
        {
            var elementFromPrefab = prefab.SpritesToElement(prefab.GetSprites().ToArray(), Quaternion.identity, size);
            VisualElement imageStack = new VisualElement();
            imageStack.Add(elementFromPrefab);
            imageStack.style.width = size;
            imageStack.style.height = size;
            return imageStack;
        }

        public static List<SpriteStruct> GetSprites(this GameObject asset)
        {
           //return new List<SpriteStruct>();             //comment out to enable level editor

            SpriteRenderer[] spriteRenderers = asset.GetComponentsInChildren<SpriteRenderer>().Where(i=>i.enabled).OrderBy(sr => sr.sortingOrder).ToArray();
            Bounds localBounds = spriteRenderers[0].bounds;
            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {
                localBounds.Encapsulate(spriteRenderer.bounds);
            }
            List<SpriteStruct> spriteStructs = new List<SpriteStruct>();
            foreach (var spriteRenderer in spriteRenderers)
            {
                if (spriteRenderer.sprite == null || spriteRenderer.enabled == false) continue;
                spriteStructs.Add(new SpriteStruct(spriteRenderer, localBounds, spriteRenderer.sprite, asset.transform));
            }

            return spriteStructs;
        }

        public static VisualElement SpritesToElement(this GameObject asset, SpriteStruct[] sprites, Quaternion transformRotation, float size)
        {
            VisualElement imageStack = new VisualElement();

            foreach (var spriteStruct in sprites)
            {
                var visualElement = spriteStruct.GetImage(size);
                imageStack.Add(visualElement);
            }

            imageStack.transform.rotation = transformRotation;
            if (transformRotation.eulerAngles.z != 0)
            {
                imageStack.style.position = Position.Absolute;
                imageStack.style.left = imageStack.style.right = imageStack.style.top = imageStack.style.bottom = Length.Percent(50);
                imageStack.style.marginLeft = imageStack.style.marginRight = imageStack.style.marginTop = imageStack.style.marginBottom = Length.Percent(-50);
            }

            return imageStack;
        }
    }
}