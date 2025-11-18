
 










using System;
using com.kshkum.ShootGame.Scripts.Audio;
using com.kshkum.ShootGame.Scripts.Gameplay.Managers;
using com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects.Attachables.Labels;
using DG.Tweening;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects.ExtraItems
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class Rocket : MonoBehaviour
    {
        private Ball ignoreCollision;
        private bool start;
        private Rigidbody2D rb;
        public Vector3 faceDirection;
        private Vector3 initialPosition;
        private Transform parent;
        private Collider2D col2D;
        private bool isReturning;
        private Vector3 initialPositionLocal;
        public Action callback;
        private Ball parentBall;
        private const float idleSpeed = .1f;
        private SpriteRenderer spriteRenderer;
        [SerializeField]
        private float timeToDestroy = 1.5f;
        [SerializeField]
        private AudioClip launchSound;
        [SerializeField]
        private float speed = 50;

        public Vector3 faceDirectionGlobal;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            faceDirectionGlobal = transform.TransformDirection(faceDirection);
            initialPosition = transform.position;
            initialPositionLocal = transform.localPosition;
            parent = transform.parent.parent;
            parentBall = parent.GetComponent<Ball>();
            col2D = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            start = false;
            transform.position = initialPosition;
            rb.linearVelocity = Vector2.zero;
            col2D.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            DOVirtual.DelayedCall(0.1f, () => ProccessCollision(other));
        }

        private void ProccessCollision(Collider2D other)
        {
            if (!start)
                return;
            var ball = other.gameObject.GetComponent<Ball>();
            if (ball != null && ball != ignoreCollision && ball.DestroyProperties.destroyByExplosion)
            {
                if(ball.label is ExtraScore label)
                    ScoreManager.instance.SetMultiplier(label.scoreMultiplier);
                BallDestructionOptions options = new BallDestructionOptions();
                options.DestroyedBy = parentBall;
                ball.DestroyBall(options);
            }
        }

        public void LaunchRocket(Ball ignoredBall)
        {
            ignoreCollision = ignoredBall;
            start = true;
            col2D.enabled = true;
            if (launchSound != null)
            {
                SoundBase.instance.PlaySound(launchSound);
            }

            spriteRenderer.sortingLayerID = SortingLayer.NameToID("FX");
        }

        private void Update()
        {
            if (!start)
            {
                // idle moving
                if (!isReturning)
                {
                    // Move to face direction
                    transform.localPosition += faceDirectionGlobal * (idleSpeed * Time.deltaTime);
                    if (Vector3.Distance(transform.localPosition, initialPositionLocal) > .1f)
                    {
                        isReturning = true; 
                    }
                }
                else
                {
                    // Move back to initial position
                    transform.localPosition -= faceDirectionGlobal * (idleSpeed * Time.deltaTime);
                    if (Vector3.Distance(transform.localPosition, initialPositionLocal) <= 0.01f)
                    {
                        isReturning = false; 
                    }
                }
                return;
            }
            
            faceDirectionGlobal = transform.TransformDirection(faceDirection);

            timeToDestroy -= Time.deltaTime;
            if (timeToDestroy <= 0)
            {
                start = false;
                transform.SetParent(parent);
                callback?.Invoke();
            }
            
            rb.linearVelocity = faceDirectionGlobal.normalized * speed;
        }
    }
}