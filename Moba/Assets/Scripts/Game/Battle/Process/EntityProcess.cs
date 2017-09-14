using GameProtocol.SceneMessage;
using UnityEngine;

public class UpdateHpProcess : BaseProcess
{
    public UpdateHpProcess() : base(BattleEventType.UpdateHp)
    {
    }

    public override void Process()
    {
        var list = GetList();
        Debug.Assert(list != null, "list != null");

        foreach (ObjectHp objectHp in list)
        {
            var fighter = EntityModel.GetFighter(objectHp.objId);
            if (fighter == null)
                continue;
            var changed = fighter.UpdateHp(objectHp);
            if (changed == 0)
                continue;
            if (objectHp.Fury == 1)
                NumberLayer.ShowNum(fighter.Data.Position, NumType.Big, changed);
            else if (changed > 0)
                NumberLayer.ShowNum(fighter.Data.Position, NumType.Green, changed);
            else
                NumberLayer.ShowNum(fighter.Data.Position, NumType.Red, changed);
        }
    }
}