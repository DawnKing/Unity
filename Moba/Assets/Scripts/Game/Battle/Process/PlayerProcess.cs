using GameProtocol.TankMessage;
using UnityEngine;

public class CreatePlayerProcess : BaseProcess
{
    public CreatePlayerProcess() : base(BattleEventType.CreatePlayer)
    {
    }

    public override void Process()
    {
        var list = GetList();
        Debug.Assert(list != null, "list != null");

        foreach (TankInfo info in list)
        {
            if (BattleModel.ContainsPlayer(info.acctOid))
            {
                BattleModel.UpdatePlayer(info);

                var data = EntityModel.GetPlayer(info.acctOid).PlayerData;
                data.UpdateData(
                    CMath.InchToMeterX(info.x),
                    CMath.InchToMeterZ(info.y),
                    info.hp,
                    info.maxHp);
            }
            else
            {
                EntityFactory.AddPlayer(info);
            }
        }
    }
}

public class DeletePlayerProcess : BaseProcess
{
    public DeletePlayerProcess() : base(BattleEventType.DeletePlayer)
    {
      
    }

    public override void Process()
    {
        var list = GetIdList();
        Debug.Assert(list != null, "list != null");

        foreach (ulong id in list)
        {
            if (!BattleModel.ContainsPlayer(id))
            {
                Debug.LogWarning("删除失败" + id);
                continue;
            }
            EntityFactory.RemovePlayer(id);
        }
    }
}
