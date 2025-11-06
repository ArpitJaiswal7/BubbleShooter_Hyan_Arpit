
 










using BubbleShooterGameToolkit.Scripts.Utils;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.PlayObjects
{
    // Class to handle the ball's collision with the screen bounds and the ball's movement
    public class BallColliderHandler
    {
        private Rigidbody2D _rb;
        private readonly CircleCollider2D _collider2D;

        // Constructor, initialize the components
        public BallColliderHandler(CircleCollider2D collider2D)
        {
            _collider2D = collider2D;
        }

        /// Set object into a static state with enabled collider
        public void SetKinematic(Ball ball, bool launched = false)
        {
            if(launched)
            {
                _rb = ball.gameObject.AddComponentIfNotExists<Rigidbody2D>();
            }

            if (_rb != null)
            {
                _rb.bodyType = RigidbodyType2D.Kinematic;
            }

            _collider2D.enabled = true;
            _collider2D.isTrigger = true;
            _collider2D.radius = launched ? 0.4f : 0.7f;
        }
        
        // disable collider
        public void DisableCollider()
        {
            if (_rb != null)
            {
                _rb.bodyType = RigidbodyType2D.Kinematic;
            }

            _collider2D.enabled = false;
        }

        /// Set object into a dynamic state to fall
        public void SetDynamic(Ball ball)
        {
            _rb = ball.gameObject.AddComponentIfNotExists<Rigidbody2D>();
            _rb.bodyType = RigidbodyType2D.Dynamic;
            _rb.gravityScale = 7f;
            _collider2D.enabled = true;
            _collider2D.isTrigger = false;
        }
        
        public bool IsColliderEnabled()=>_collider2D.enabled;


        public void AddForce(Vector2 vector2)
        {
            Debug.Log("Force added to the ball it should hit other balls");
            _rb.AddForce(vector2);
        }
    }
}