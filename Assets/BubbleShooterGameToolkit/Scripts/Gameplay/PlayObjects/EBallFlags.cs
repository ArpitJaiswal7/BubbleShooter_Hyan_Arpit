
 










using System;

namespace com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects
{
    [Flags]
    public enum EBallFlags
    {
        None = 0,
        Animating = 1 << 0,  // 1  - for wave effect
        MarkedForMatch = 1 << 1,  // 2  - for matching
        MarkConnected = 1 << 2,  // 4 - for falling separated balls
        Falling = 1 << 3,  // 8 - for falling balls
        MarkedForDestroy = 1 << 4,  // 16 - for destroying balls
        DirtyToCheckNeighbours = 1 << 5,  // 32 - for checking neighbours
        Destroying = 1 << 6,  // 64 - for destroying balls
        Pinned = 1 << 7, // 128 - used for all static balls on field
        Root = 1 << 8, // 256 - can this ball hold balls like supporting structure
        IgnoreRaycast = 1 << 9, // 512 - temp flag to avoid by launching ball, not consider as neighbour
    }
}