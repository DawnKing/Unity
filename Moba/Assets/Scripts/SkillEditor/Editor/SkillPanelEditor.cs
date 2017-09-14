using UnityEditor;

[CustomEditor(typeof(SkillDisplay))]
public class SkillPanelEditor : Editor
{
    private SerializedProperty _displayType;
    private SerializedProperty _playType;
    private SerializedProperty _positionType;
    private SerializedProperty _rotateType;

    //private string[] _propertyToExclude;

    public void OnEnable()
    {
        _displayType = serializedObject.FindProperty("_displayType");
        _playType = serializedObject.FindProperty("_playType");
        _positionType = serializedObject.FindProperty("_positionType");
        _rotateType = serializedObject.FindProperty("_rotateType");

        //_propertyToExclude = new[] {"m_Script", "_skillName", "_desc", "_skillType", "_displayTypeType"};
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        SkillDisplay display = target as SkillDisplay;

        //DrawPropertiesExcluding(serializedObject, _propertyToExclude);

        EditorGUILayout.PropertyField(_displayType);
        EditorGUILayout.PropertyField(_playType);
        EditorGUILayout.PropertyField(_positionType);
        EditorGUILayout.PropertyField(_rotateType);

        if (serializedObject.ApplyModifiedProperties())
        {
            if (PrefabUtility.GetPrefabType(display) != PrefabType.Prefab)
            {
                display.ApplyModifiedProperties();
            }
        }
    }
}
