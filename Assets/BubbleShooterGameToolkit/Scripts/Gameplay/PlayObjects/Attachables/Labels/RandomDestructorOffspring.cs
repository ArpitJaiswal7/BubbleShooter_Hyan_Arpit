
 










using com.kshkum.ShootGame.Scripts.Audio;
using com.kshkum.ShootGame.Scripts.Gameplay.Managers;
using com.kshkum.ShootGame.Scripts.Gameplay.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects.Attachables.Labels
{
    public class RandomDestructorOffspring : MonoBehaviour
    {
        public float speed = 0.5f; // speed of movement
        private Vector3 startPosition; // start position
        private float startTime; // time at the start of path
        private Ball targetBall; // target ball to follow
        private Vector3 randomIdlePosition; // random idle position
        private Ball randomBall;
        [SerializeField]
        private GameObject fxPrefab;
        [SerializeField]
        private AudioClip destroySound;

        private RandomDesctructorManager randomDesctructorManager;
        private bool reachedTarget;
        private bool hasCheckedAtHalfway;

        public void Init(Vector3 position, RandomDesctructorManager randomDesctructorManager)
        {
            this.randomDesctructorManager = randomDesctructorManager;
            reachedTarget = false;
            hasCheckedAtHalfway = false;
            transform.position = position;
            randomIdlePosition = transform.position + (Vector3)Random.insideUnitCircle * 1.5f;
        }

        public void StartFly()
        {
            LookForNewTarget(null);
            startPosition = transform.position;
            startTime = Time.time;
        }

        private void LookForNewTarget(BallDestructionOptions destroyedby)
        {
            if (!reachedTarget)
            {
                if (targetBall != null)
                {
                    targetBall.OnDestroy -= LookForNewTarget;
                }
                targetBall = randomDesctructorManager.GetTarget(this, transform.position);
                if (targetBall != null)
                {
                    targetBall.OnDestroy += LookForNewTarget;
                    startTime = Time.time;
                    startPosition = transform.position;
                    hasCheckedAtHalfway = false;
                }
                else
                {
                    OnFinished();
                }
            }
        }

        void Update()
        {
            if (targetBall != null)
            {
                float fracJourney = (Time.time - startTime) * speed;
                Vector3 newPosition = Vector3.Lerp(startPosition, targetBall.transform.position, fracJourney);

                // adding arc motion
                newPosition.y += Mathf.Sin(fracJourney * Mathf.PI) * 0.5f;

                // update the object's position
                transform.position = newPosition;
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one*.5f, Time.deltaTime * 2f);

                if(fracJourney >= 0.5f && !hasCheckedAtHalfway)
                {
                    CheckTargetCondition();
                    hasCheckedAtHalfway = true;
                }
                
                if (fracJourney >= 1)
                {
                    OnFinished();
                }
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, randomIdlePosition, Time.deltaTime * 2f);
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one*1.5f, Time.deltaTime * 2f);
            }
            //rotation loop around z axis
            transform.Rotate(0, 0, 360 * Time.deltaTime);
        }

        public void OnFinished()
        {
            if (CheckTargetCondition())
            {
                return;
            }

            reachedTarget = true;
            if (targetBall != null)
            {
                targetBall.DestroyBall();
                targetBall.OnDestroy -= LookForNewTarget;
                targetBall = null;
            }
            var fx = PoolObject.GetObject(fxPrefab);
            fx.transform.position = transform.position;
            SoundBase.instance.PlaySound(destroySound);
            PoolObject.Return(gameObject);
            EventManager.GetEvent(EGameEvent.CheckSeparatedBalls).Invoke();
        }

        private bool CheckTargetCondition()
        {
            if (targetBall != null && (targetBall.Flags.HasFlag(EBallFlags.Destroying) || targetBall.Flags.HasFlag(EBallFlags.Falling) || !targetBall.gameObject.activeSelf))
            {
                targetBall = null;
                LookForNewTarget(null);
                return true;
            }

            return false;
        }
    }
}