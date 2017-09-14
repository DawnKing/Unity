using System;
using UnityEngine;

public class EditorSkillProcess : BaseProcess
{
    private const string TankName = "SkillEditor";
    private const string SkillName = "Skill";

    private readonly SkillModel _skillModel;

    public EditorSkillProcess() : base(BattleEventType.AttachJoystick)
    {
        _skillModel = SkillModel.Inst;

        var skill = GameObject.FindGameObjectWithTag(BattleTag.Skill);
        if (skill == null)
        {
            Debug.LogError("未找到Tag为Skill的对象");
            return;
        }
        BattleResource.PushSkillCache(TankName, SkillName, skill);
    }

    public override bool IsProcess()
    {
        if (BattleModel.Self == null)
            return false;
        return base.IsProcess();
    }

    public override void Process()
    {
        var selfPlayer = BattleModel.Self;

        if (_skillModel.IsSkillCooling(0))
            return;
        _skillModel.AddSkillCooling(0, SkillEditor.Inst.SkillTime);

        float radian = Convert.ToSingle(GetParam());
        float fromX = selfPlayer.Data.X;
        float fromZ = selfPlayer.Data.Z;
        float toX = Mathf.Sin(radian) * 10 + fromX;
        float toZ = Mathf.Cos(radian) * 10 + fromZ;
        var speed = CMath.InchToMeter(BattleModel.SelfData.speed);

        BattleResource.GetSkill(TankName, SkillName, skill =>
        {
            if (skill == null)
                return;
            SkillTool.AddSkill(skill, selfPlayer.Id, AnimationType.Skill1, fromX, fromZ, toX, toZ, radian, speed, selfPlayer.FighterAvatar.FirePosition, TankName, SkillName);
        });
    }
}