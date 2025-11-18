
 










using System.Linq;
using com.kshkum.ShootGame.Scripts.CommonUI.Tutorials;
using com.kshkum.ShootGame.Scripts.Gameplay.PlayObjects;
using UnityEditor;
using UnityEngine.UIElements;

namespace com.kshkum.ShootGame.Scripts.Editor
{
    [CustomEditor(typeof(TutorialSetup))]
    public class TutorialSetupEditor : UnityEditor.Editor
    {
        public VisualTreeAsset visualTreeAsset;

        public override VisualElement CreateInspectorGUI()
        {
            //target
            var tutorialSetup = (TutorialSetup) target;
            var root = new VisualElement();
            visualTreeAsset.CloneTree(root);
            var ballsPrefab = EditorItemsLoader.GetItems();
            var ballValues = ballsPrefab.Select(i=>i.Prefab.GetComponent<Ball>()).Where(i=>i!=null && !i.name.Contains("_")).ToList();
            var ballLabels = ballValues.Select(b => b.name).ToList();
            var list = new PopupField<string>("Launch Ball", ballLabels, 0);
            list.value = ballLabels.Find(i=>i==tutorialSetup?.launchBall?.name)??"";

            list.RegisterValueChangedCallback(evt =>
            {
                if (evt.newValue != null)
                {
                    tutorialSetup.launchBall = ballValues[ballLabels.IndexOf(evt.newValue)];
                    
                    //save prefab
                    EditorUtility.SetDirty(tutorialSetup);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                }
            });
            root.Add(list);

            return root;
        }
    }
}