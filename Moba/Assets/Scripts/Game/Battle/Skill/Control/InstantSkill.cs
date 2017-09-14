using UnityEngine;

public class InstantSkill : SkillEntity
{
    public override void Play(SkillDisplay skillDisplay)
    {
        base.Play(skillDisplay);
        switch (skillDisplay.PositionType)
        {
            case SkillPosition.Self:
                SkillData.SetPosition(SkillData.From);
                break;
            case SkillPosition.Target:
                SkillData.SetPosition(SkillData.To);
                break;
        }

        switch (skillDisplay.RotateType)
        {
            case SkillRotate.None:
                SkillData.SetRotation(Quaternion.identity);
                break;
            case SkillRotate.Target:
                SkillData.SetRotation(SkillData.Rotation);
                break;
        }
    }
}
