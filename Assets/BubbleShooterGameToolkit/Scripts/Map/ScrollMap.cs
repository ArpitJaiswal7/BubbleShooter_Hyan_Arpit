
 










using UnityEngine;
using UnityEngine.UI;

namespace com.kshkum.ShootGame.Scripts.Map
{
    public class ScrollMap : MonoBehaviour
    {
         
        [SerializeField]
        private ScrollRect scrollRect;
     
        private void OnEnable()
        {
            MapManager.OnLastLevelPosition += ScrollToAvatar;
        }
        
        private void OnDisable()
        {
            MapManager.OnLastLevelPosition -= ScrollToAvatar;
        }

        private void ScrollToAvatar(Vector2 vector2)
        {
            Vector2 contentPositionInLocalSpace = scrollRect.transform.InverseTransformPoint(scrollRect.content.position);
            Vector2 avatarPositionInLocalSpace = scrollRect.transform.InverseTransformPoint(vector2);

            Vector2 contentAnchoredPosition = contentPositionInLocalSpace - avatarPositionInLocalSpace;

            float aspectRatio = Screen.height / Screen.width;
            float centerOffset = aspectRatio * 1000f;

            scrollRect.content.anchoredPosition = new Vector2(0, contentAnchoredPosition.y + centerOffset);
        }
    }
}