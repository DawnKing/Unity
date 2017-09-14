using FairyGUI;
using System;
using UnityEngine;

public class InputMoveProcess : BaseProcess
{
    public InputMoveProcess() : base(BattleEventType.MoveJoystick)
    {
    }

    public override bool IsProcess()
    {
        if (BattleModel.Self == null)
            return false;
        return base.IsProcess();
    }

    public override void Process()
    {
        if (!BattleModel.Self.IsMovable())
            return;
        float direction = Convert.ToSingle(GetParam());

        var selfData = BattleModel.Self.SelfData;
        float targetX = Mathf.Sin(direction) + selfData.X;
        float targetZ = Mathf.Cos(direction) + selfData.Z;

        BattleTool.AddMove(BattleModel.Self.Id, selfData.X, selfData.Z, targetX, targetZ, direction, selfData.Speed);
    }
}

public class InputAttackProcess : BaseProcess
{
    private readonly SkillModel _skillModel;

    public InputAttackProcess() : base(BattleEventType.AttachJoystick)
    {
        _skillModel = SkillModel.Inst;
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

        if (!selfPlayer.IsAttack())
            return;

        if (_skillModel.IsSkillCooling(0))
            return;
        _skillModel.AddSkillCooling(0, 0.5f);

        float radian = Convert.ToSingle(GetParam());
        float fromX = selfPlayer.Data.X;
        float fromZ = selfPlayer.Data.Z;
        float toX = Mathf.Sin(radian) * 10 + fromX;
        float toZ = Mathf.Cos(radian) * 10 + fromZ;
        var speed = CMath.InchToMeter(BattleModel.SelfData.speed);

        SkillTool.AddSkill(selfPlayer.Id, 1, AnimationType.Attack, 
            fromX, fromZ, toX, toZ, 
            radian, speed, selfPlayer.FighterAvatar.FirePosition);
    }
}

public class SelfSkillProcess : BaseProcess
{
    private readonly SkillModel _skillModel;

    public uint SkillId { get; set; }

    public SelfSkillProcess() : base(BattleEventType.Skill1)
    {
        _skillModel = SkillModel.Inst;
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

        if (!selfPlayer.IsAttack())
            return;

        if (_skillModel.IsSkillCooling(SkillId))
            return;
        _skillModel.AddSkillCooling(SkillId, 2.0f);

        SkillHandler(null);

        Timers.inst.Add(.5f, 2, SkillHandler);
    }

    private void SkillHandler(object param)
    {
        var selfPlayer = BattleModel.Self;

        float fromX = selfPlayer.Data.X;
        float fromZ = selfPlayer.Data.Z;
        float toX = 0;
        float toZ = 0;
        if (BattleModel.Target != null)
        {
            toX = BattleModel.Target.Data.Position.x;
            toZ = BattleModel.Target.Data.Position.z;
        }
        float radian = Mathf.Atan2(toX - fromX, toZ - fromZ);
        var speed = CMath.InchToMeter(BattleModel.SelfData.speed);

        SkillTool.AddSkill(selfPlayer.Id, SkillId, AnimationType.Skill1, 
            fromX, fromZ, toX, toZ, 
            radian, speed, selfPlayer.FighterAvatar.FirePosition);
    }
}