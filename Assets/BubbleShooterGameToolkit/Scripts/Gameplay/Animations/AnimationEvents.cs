
 










using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Gameplay.Animations
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