using UnityEditor;
using UnityEngine;

public class EditorToolSet
{
    [MenuItem("Game/Skill/Skill")]
    public static void CreateSkill()
    {
        GameObject skill = new GameObject("Skill");
        skill.AddComponent<SkillDisplay>();
        Selection.objects = new Object[] { skill };
    }
}