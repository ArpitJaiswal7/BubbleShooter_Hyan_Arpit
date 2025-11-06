
 










using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using DG.Tweening;
using UnityEngine.Rendering;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.BubbleContainers
{
    public class BoostBallContainer : BallContainerBase
    {
        public void ReleaseBoost(string prefab)
        {
            BallCharged = SpawnBall(prefab);

            if (BallCharged)
            {
                transform.DOKill();
                LevelManager.instance.launchContainer.SaveBall();
                var sortingGroup = BallCharged.gameObject.AddComponent<SortingGroup>();
                sortingGroup.sortingLayerName = "UI";
                SwitchBall(this, LevelManager.instance.launchContainer, BallCharged, (b)=> LevelManager.instance.launchContainer.BallCharged = b );
                BallCharged = null;
            }
        }
    }
}