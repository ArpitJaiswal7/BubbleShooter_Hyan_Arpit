#if UNITY_EDITOR
using com.kshkum.ShootGame.Scripts.Ads;
using com.kshkum.ShootGame.Scripts.Ads.AdUnits;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace com.kshkum.ShootGame.Scripts.Settings.Editor
{
    [CustomPropertyDrawer(typeof(AdElement))]
    public class AdElementDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            // Create a new VisualElement
            var root = new VisualElement();

            // Add placementId field
            var placementIdField = new PropertyField(property.FindPropertyRelative("placementId"));
            root.Add(placementIdField);

            // Add adTypeScriptable field
            var adTypeScriptableProperty = property.FindPropertyRelative("adReference");
            var adTypeScriptableField = new PropertyField(adTypeScriptableProperty);
            root.Add(adTypeScriptableField);

            // Add popup field
            var popupField = new PropertyField(property.FindPropertyRelative("popup"));
            root.Add(popupField);

            adTypeScriptableField.RegisterValueChangeCallback(evt =>
            {
                // Retrieve the selected adType from the AdTypeScriptable
                var adTypeScriptableObject = (AdReference)adTypeScriptableProperty.objectReferenceValue;
                if (adTypeScriptableObject != null && adTypeScriptableObject.adType == EAdType.Interstitial)
                {
                    root.Add(popupField);
                }
                else
                {
                    if (root.Contains(popupField))
                    {
                        root.Remove(popupField);
                    }
                }
            });

            // Add popup field only if adType is not Rewarded
            if (adTypeScriptableProperty != null)
            {
                var adTypeScriptableObject = (AdReference)adTypeScriptableProperty.objectReferenceValue;
                if (adTypeScriptableObject != null && adTypeScriptableObject.adType == EAdType.Rewarded)
                {
                    root.Remove(popupField);
                }
            }

            // Return the root VisualElement
            return root;
        }
    }
}
#endif