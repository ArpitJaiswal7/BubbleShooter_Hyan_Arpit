
 










using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.PlayObjects.Attachables.Labels
{
    public class ExtraMovesTime : LabelItem
    {
        public int movesTime = 5;

        public override bool DestroyItem(BallDestructionOptions options = null)
        {
            MovesTimeManager.instance.AddMoves(movesTime);
            return base.DestroyItem(options);
        }
    }
}