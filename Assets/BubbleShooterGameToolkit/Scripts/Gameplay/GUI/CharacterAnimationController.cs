
 










using BubbleShooterGameToolkit.Scripts.Enums;
using BubbleShooterGameToolkit.Scripts.Gameplay.BubbleContainers;
using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using BubbleShooterGameToolkit.Scripts.Gameplay.PlayObjects;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.GUI
{
    public class CharacterAnimationController : MonoBehaviour
    {
        private Animator animator;
        private static readonly int Warning = Animator.StringToHash("Warning");
        private static readonly int Throw = Animator.StringToHash("Throw");

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            GameUIManager.OnMovesUpdated += OnMovesUpdated;
            BallContainerBase.OnBallSwitched += ThrowAnimation;
            BallContainerBase.OnBallLaunched += ThrowAnimation;
            EventManager.GetEvent<EStatus>(EGameEvent.Win).Subscribe(OnWin);
        }

        private void OnWin(EStatus obj)
        {
            BallContainerBase.OnBallLaunched -= ThrowAnimation;
            animator.SetBool(Warning, false);
        }

        private void ThrowAnimation(Ball ball)
        {
            animator.SetTrigger(Throw);
        }

        private void OnDisable()
        {
            GameUIManager.OnMovesUpdated -= OnMovesUpdated;
            BallContainerBase.OnBallSwitched -= ThrowAnimation;
            BallContainerBase.OnBallLaunched -= ThrowAnimation;
            EventManager.GetEvent<EStatus>(EGameEvent.Win).Unsubscribe(OnWin);
        }

        private void OnMovesUpdated(int moves, bool thresholdReached)
        {
            if(EventManager.GameStatus == EStatus.Play)
                animator.SetBool(Warning, thresholdReached);
        }
    }
}