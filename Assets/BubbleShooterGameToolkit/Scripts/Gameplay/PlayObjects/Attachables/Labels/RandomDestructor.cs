
 










using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects.Attachables.Labels
{
    public class RandomDestructor : LabelItem
    {
        private Vector3 center;

        public override void OnEnable()
        {
            base.OnEnable();
            center = transform.localPosition;
        }

        private void Update()
        {
            transform.localPosition = center + new Vector3(Mathf.Sin(-Time.time * 2), Mathf.Cos(-Time.time * 2), 0) * .2f;
            transform.localRotation = Quaternion.Euler(0, 0, Time.time * 100);
        }

        public override void SetPosition(Vector3 transformPosition)
        {
            transform.position = ball.transform.position + new UnityEngine.Vector3(.2f, .2f, 0);
            transform.localRotation = UnityEngine.Quaternion.Euler(0, 0, 30);
        }
    }
}