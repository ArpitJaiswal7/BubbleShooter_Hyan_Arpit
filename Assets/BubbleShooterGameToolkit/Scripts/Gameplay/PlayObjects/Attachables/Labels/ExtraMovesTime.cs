
 










using com.kshkum.ShootGame.Scripts.Gameplay.Managers;

namespace com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects.Attachables.Labels
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