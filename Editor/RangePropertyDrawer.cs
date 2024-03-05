using UnityEditor;
using UnityEngine;

namespace Fofanius.Types.Editor
{
    [CustomPropertyDrawer(typeof(Fofanius.Types.Range))]
    public class RangePropertyDrawer : PropertyDrawer
    {
        private const float DEFAULT_HEIGHT = 18f;
        private const float DRAWED_PROPERTY_HEGITH = DEFAULT_HEIGHT * 3f;
        private const float SPACING = 8f;

        private const string A_PROPERTY_KEY = "_a";
        private const string B_PROPERTY_KEY = "_b";

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => DRAWED_PROPERTY_HEGITH;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            position.height = DEFAULT_HEIGHT;

            EditorGUI.LabelField(position, property.displayName);

            var a = property.FindPropertyRelative(A_PROPERTY_KEY);
            var b = property.FindPropertyRelative(B_PROPERTY_KEY);

            position.y += DEFAULT_HEIGHT;
            position.x += SPACING;
            position.width -= SPACING * 2f;

            var aValue = EditorGUI.FloatField(position, a.displayName, a.floatValue);
            a.floatValue = Mathf.Min(aValue, b.floatValue);

            position.y += DEFAULT_HEIGHT;

            var bValue = EditorGUI.FloatField(position, b.displayName, b.floatValue);
            b.floatValue = Mathf.Max(a.floatValue, bValue);
        }
    }
}
