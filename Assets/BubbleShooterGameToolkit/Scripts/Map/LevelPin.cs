
 










using com.kshkum.ShootGame.Scripts.LevelSystem;
using TMPro;
using UnityEngine;

namespace com.kshkum.ShootGame.Scripts.Map
{
    public class LevelPin : MonoBehaviour
    {
        [SerializeField]
        public int number = 1;
        [SerializeField]
        private GameObject lockObj;
        [SerializeField]
        private Transform starsGrid;
        [SerializeField]
        private GameObject starPrefab;

        [SerializeField]
        public Transform avatarPivot;

        [SerializeField]
        private TextMeshProUGUI numberLabel;

        private bool isLocked;

        private void OnEnable()
        {
            //delete all stars
            for (int i = 0; i < starsGrid.childCount; i++)
            {
                Destroy(starsGrid.GetChild(i).gameObject);
            }
        }

        private void OnValidate()
        {
            number = transform.GetSiblingIndex() + 1;
            name = "Level_" + number;
            numberLabel.text = number.ToString();
        }

        public void Lock()
        {
            isLocked = true;
            numberLabel.gameObject.SetActive(false);
            lockObj.SetActive(true);
        }
        
        public void UnLock()
        {
            isLocked = false;
            numberLabel.gameObject.SetActive(true);
            lockObj.SetActive(false);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(avatarPivot.position, .1f);
        }

        public void MouseDown()
        {
            if (isLocked)
                return;
            MapManager.instance.OpenLevel(number);
        }

        public void SetScore(int score)
        {
            var level = Resources.Load<Level>("Levels/Level_" + number);
            if (level == null)
            {
                Debug.LogError("Level_" + number + " not found");
                return;
            }
            var stars = level.stars;
            for (int i = 0; i < stars.Length; i++)
            {
                if (stars[i] <= score)
                {
                    var star = Instantiate(starPrefab, starsGrid);
                    star.SetActive(true);
                }
            }
        }
    }
}