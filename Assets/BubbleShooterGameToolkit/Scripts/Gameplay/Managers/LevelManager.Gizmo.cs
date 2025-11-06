
 










namespace BubbleShooterGameToolkit.Scripts.Gameplay.Managers
{
    public partial class LevelManager
    {
        private void OnDrawGizmos()
        {
            // if (Level is not null)
            // {
            //     for (int y = 0; y < Level.sizeY; y++)
            //     {
            //         for (int x = 0; x < Level.sizeX; x++)
            //         {
            //             var position = LevelUtils.PosToWorld(new Vector2Int(x,y));
            //             Gizmos.color = Color.red;
            //             Gizmos.DrawSphere(position, 0.1f);
            //         }
            //     }
            // }
            
            // // raycast from cannon to mouse position
            // if (launchContainer is not null)
            // {
            //     var mousePos = Input.mousePosition;
            //     mousePos.z = 10;
            //     var mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
            //     Gizmos.color = Color.green;
            //     var transformPosition = launchContainer.transform.position;
            //     Gizmos.DrawLine(transformPosition, mouseWorldPos);
            //     Gizmos.color = Color.green;
            //     var worldToPos = LevelUtils.WorldToPos(mouseWorldPos);
            //     var checkPosition = LevelUtils.CheckPosition(worldToPos.x, worldToPos.y);
            //     
            //     Gizmos.DrawSphere(LevelUtils.PosToWorld(checkPosition), 0.3f);
            // }
        }
    }
}