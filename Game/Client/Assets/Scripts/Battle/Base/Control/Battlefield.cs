using System.Collections.Generic;
using Assets.Scripts.Battle.Base.Control;
using Assets.Scripts.Battle.Base.Model;

public sealed class Battlefield
{
    private BattleModel _battleModel;

    private readonly List<BaseProcess> _processes = new List<BaseProcess>();

    public void Init()
    {
        _battleModel = BattleModel.Inst;

        SelfPlayer self = _battleModel.SelfPlayer;
//        _processes.Add(new TargetProcess(BattleEventType.SelectTarget, self));
        _processes.Add(new InputMoveProcess(BattleEventType.MoveJoystick, self));

        _processes.Add(new CreateEntityProcess(BattleEventType.CreateEntity));
        _processes.Add(new EntityMoveProcess());
//        _processes.Add(new CameraMoveProcess());
    }

    public void Process()
    {
        int length = _processes.Count;
        for (int i = 0; i < length; i++)
        {
            BaseProcess p = _processes[i];
            if (!p.IsProcess())
                continue;
            p.Process();
            p.Complete();
        }
    }
}