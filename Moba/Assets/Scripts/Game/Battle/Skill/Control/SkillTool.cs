using UnityEngine;

public static class SkillTool
{
    public static void AddSkill(ulong castId, uint skillId, string animationType, 
        float fromX, float fromZ, float toX, float toZ, 
        float radian, float speed, Transform firePosition)
    {
        var skillTplt = SkillTemplateData.GetData(skillId, typeof(SkillTool));
        if (skillTplt == null)
            return;
        BattleResource.GetSkill(skillTplt.SkillEffectRes, animationType, obj =>
        {
            if (obj == null)
                return;
            AddSkill(obj, castId, animationType, 
                fromX, fromZ, toX, toZ, 
                radian, speed, firePosition, 
                skillTplt.SkillEffectRes, animationType);
        });
    }

    public static void AddSkill(GameObject obj, ulong castId, string animationType, 
        float fromX, float fromZ, float toX, float toZ, float radian, float speed, 
        Transform firePosition, string tankName, string skillName)
    {
        var caster = EntityModel.GetFighter(castId);
        if (caster != null)
        {
            caster.FighterAvatar.SetSkill(animationType, radian);
        }

        var skillPanel = obj.GetComponent<SkillDisplay>();
        if (skillPanel == null)
        {
            Debug.LogWarning("对象没有SkillPanel");
            return;
        }
        var entity = SkillFactory.Create(skillPanel.DisplayType, skillPanel.PlayType);
        if (entity == null)
            return;
        entity.Set();

        var y = firePosition == null ? 0 : firePosition.position.y;
        entity.SkillData.UpdateData(fromX, fromZ, toX, toZ, radian, speed, y);
        entity.SkillAvatar.SetModel(obj, tankName, skillName);

        EntityModel.AddEntity(entity);

        entity.Play(skillPanel);
    }
}
