
 










using System.Collections.Generic;
using BubbleShooterGameToolkit.Scripts.CommonUI.Popups;
using BubbleShooterGameToolkit.Scripts.Gameplay.Managers;
using BubbleShooterGameToolkit.Scripts.LevelSystem;
using UnityEngine;

namespace BubbleShooterGameToolkit.Scripts.Gameplay.Targets
{
    public class TargetContainerUI : MonoBehaviour
    {
        [SerializeField] private TargetObjectUI targetPrefab;

        private void OnEnable()
        {
            if(GetComponentInParent<Popup>())
                TargetsForPopup();
        }

        public List<TargetObjectUI> PrepareTargets(List<Target> leveltargets)
        {
            List<TargetObjectUI> targetObjectUIs = new List<TargetObjectUI>();
            foreach (var targets in leveltargets)
            {
                if (!targets.target.countFromField && targets.count == 0) continue;

                var targetObjectUI = Instantiate(targetPrefab, transform, true);
                targetObjectUI.transform.localScale = Vector3.one;
                targetObjectUI.transform.localPosition = Vector3.one;
                targetObjectUI.image.sprite = targets.target.uiIcon;
                targetObjectUIs.Add(targetObjectUI);
            }

            return targetObjectUIs;
        }

        //get targets from target manager for popup
        private void TargetsForPopup()
        {
            var _targetObjectControllers = TargetManager.instance._targetObjectControllers;
            foreach (var targets in LevelLoader.instance.CurrentLevel.targets)
            {
                var targetObjectUI = Instantiate(targetPrefab, transform, true);
                targetObjectUI.transform.localScale = Vector3.one;
                targetObjectUI.transform.localPosition = Vector3.one;
                targetObjectUI.image.sprite = targets.target.uiIcon;
                if(_targetObjectControllers.Count > 0)
                {
                    TargetObjectModel model = _targetObjectControllers.Find(x => x.GetModel().target == targets.target).GetModel();
                    targetObjectUI.UpdateTarget(model.Count, model.IsDone(), MovesTimeManager.instance.GetMoves());
                }
                else
                    targetObjectUI.UpdateTarget(targets.count, false, 1);
            }
        }
    }
}