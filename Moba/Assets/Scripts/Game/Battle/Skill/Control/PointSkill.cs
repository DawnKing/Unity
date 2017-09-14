using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSkill : InstantSkill
{
    public override void Play(SkillDisplay skillDisplay)
    {
        base.Play(skillDisplay);
        EntityModel.AddMoveList(Id, 
            SkillData.From.x, SkillData.From.z, 
            SkillData.To.x, SkillData.To.z, 
            SkillData.Radian, 10);
    }

    public override void UpdateMove(float time, out bool isMove, out bool moveEnd)
    {
        base.UpdateMove(time, out isMove, out moveEnd);

        if (!moveEnd)
            return;
        SkillAvatar.MoveEnd();
        BattleEvent.Inst.AddEvent(BattleEventType.DeleteSkill, Id);
    }
}
