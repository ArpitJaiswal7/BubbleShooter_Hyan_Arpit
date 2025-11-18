
 










using com.kshkum.ShootGame.Scripts.Gameplay.Pool;
using TMPro;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Gameplay.Animations
{
    //score pop-up animation
    public class ScoreAnim : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI textMeshPro;

        [SerializeField]
        private Animator animator;

        public void StartAnim(string toString)
        {
            textMeshPro.text = toString;
            animator.Play("ScorePlay");
        }

        public void Finished()
        {
            PoolObject.Return(gameObject);
        }
    }
}
