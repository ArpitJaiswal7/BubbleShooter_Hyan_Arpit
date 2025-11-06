
 










using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.GUI
{
    public class SafeArea : MonoBehaviour
    {
        [SerializeField]
        private RectTransform rectCanvasTransform;

        private void Awake()
        {
            var rectTransform = rectCanvasTransform;
            var safeArea = Screen.safeArea;
            var anchorMin = safeArea.position;
            var anchorMax = anchorMin + safeArea.size;

            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            rectTransform.anchorMin = anchorMin;
            rectTransform.anchorMax = anchorMax;
        }
    }
}