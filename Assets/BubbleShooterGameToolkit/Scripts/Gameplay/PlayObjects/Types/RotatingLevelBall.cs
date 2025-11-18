
 










using com.kshkum.ShootGame.Scripts.Audio;
using com.kshkum.ShootGame.Scripts.Gameplay.Managers;
using com.kshkum.ShootGame.Scripts.LevelSystem;
using com.kshkum.ShootGame.Scripts.System;
using com.kshkum.ShootGame.Scripts.Utils;
using Unity.Mathematics;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects.Types
{
    public class RotatingLevelBall : SingletonBehaviour<RotatingLevelBall>
    {
        float angle;
        private Rigidbody2D rb;
        public int rotatingField = 3;
        private Transform rotationTransform;
        private Quaternion newRot;

        void Start()
        {
            rotationTransform = new GameObject("Rotation").transform;
            rotationTransform.SetParent(transform.parent);
            GetComponent<Ball>().Flags |= EBallFlags.Root;
            transform.localScale *= 1.2f;
            LevelUtils.CleanUpBallsForRotatingLevel(GetRotationParent(), LevelManager.instance.balls);
            transform.SetParentPosition(transform.position);
            rb = rotationTransform.gameObject.AddComponent<Rigidbody2D>();
            rb.angularDamping = 1;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            rotationTransform.rotation = quaternion.Euler(0,0,0);
            LevelManager.instance.ball_center_pivot = transform;
        }

        public Transform GetRotationParent() => rotationTransform;

        public void Rotate(Vector3 ballPosition)
        {
            var direction = rotationTransform.position;

            angle = Vector2.Angle(direction - ballPosition, ballPosition - transform.position) / 4f;

            if (transform.position.x < ballPosition.x)
                angle *= -1;

            newRot = transform.rotation * Quaternion.AngleAxis(angle, Vector3.back);

            SoundBase.instance.GetComponent<AudioSource>().PlayOneShot(SoundBase.instance.rotation);
        }
        
        void Update()
        {
            if( rotationTransform.rotation != newRot )
                rotationTransform.rotation = Quaternion.Lerp( rotationTransform.rotation, newRot, Time.deltaTime);
        }

        public bool IsRotating()
        {
            return Mathf.Abs(rotationTransform.rotation.eulerAngles.z - newRot.eulerAngles.z) > 1.0f;
        }
    }
}