
 










using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.Animations
{
    public class AnimationEvents : MonoBehaviour
    {
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}