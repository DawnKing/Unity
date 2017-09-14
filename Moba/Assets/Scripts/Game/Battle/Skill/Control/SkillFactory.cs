using UnityEngine;

public static class SkillFactory
{
    public static SkillEntity Create(SkillDisplayType displayTypeType, SkillPlay playType)
    {
        SkillEntity entity = null;
        switch (displayTypeType)
        {
            case SkillDisplayType.Single:
                entity = CreateSingle(playType);
                break;
            default:
                Debug.LogError(displayTypeType + "," + playType);
                break;
        }
        return entity;
    }

    private static SkillEntity CreateSingle(SkillPlay playType)
    {
        SkillEntity entity = null;
        switch (playType)
        {
            case SkillPlay.Instant:
                break;
            case SkillPlay.Unit:
                break;
            case SkillPlay.Point:
                entity = EntityModel.PopSkillEntity(typeof(PointSkill)) as PointSkill ?? new PointSkill();
                break;
            default:
                Debug.LogError(playType);
                break;
        }
        return entity;
    }

    public static void RemoveSkill(ulong id)
    {
        EntityModel.RemoveEntity(id);
    }
}
