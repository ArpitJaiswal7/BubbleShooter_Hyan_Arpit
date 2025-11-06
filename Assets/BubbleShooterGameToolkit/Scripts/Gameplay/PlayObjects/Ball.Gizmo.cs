
 










using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.PlayObjects
{
    public partial class Ball
    {
        private void OnDrawGizmosSelected()
        {
            if(!Application.isPlaying)
                return;
            Gizmos.color = new Color(1, 1, 0, 0.5f);
            Gizmos.DrawSphere(transform.position, 0.4f);
            
            // mark neighbours
            Gizmos.color = Color.green;
            for (int i = 0; i < neighbours.Length; i++)
            {
                if (neighbours[i] != null)
                {
                    Gizmos.DrawLine(transform.position, neighbours[i].transform.position);
                }
            }
        }
        
        #if UNITY_EDITOR
        void OnDrawGizmos() 
        {
            if(!Application.isPlaying)
                return;
            UnityEditor.Handles.Label(transform.position+ Vector3.one*0.1f, (position.x + ":" + position.y));
            UnityEditor.Handles.color = Color.white;
        }
        #endif
    }
}