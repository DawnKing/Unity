using GameProtocol.TankMessage;
using UnityEngine;

public static class EntityFactory
{
    public static void AddSelfPlayer(TankInfo tankInfo)
    {
        ulong id = tankInfo.acctOid;

        var selfPlayer = new SelfPlayer();
        selfPlayer.Set(id);

        BattleModel.Self = selfPlayer;

        AddPlayerHandler(selfPlayer, tankInfo);
    }

    public static void AddPlayer(TankInfo tankInfo)
    {
        ulong id = tankInfo.acctOid;

        Player player = EntityModel.PopEntity(typeof(Player)) as Player ?? new Player();
        player.Set(id);

        AddPlayerHandler(player, tankInfo);
    }

    private static void AddPlayerHandler(Player player, TankInfo tankInfo)
    {
        var x = CMath.InchToMeterX(tankInfo.x);
        var z = CMath.InchToMeterZ(tankInfo.y);

        player.Data.UpdateData(new Vector3(x, 0, z), new Quaternion());
        player.FighterData.UpdateFigter(tankInfo.hp, tankInfo.maxHp);

        player.Avatar.Set(player.Id, tankInfo.name);

        EntityModel.AddEntity(player);
        BattleModel.AddPlayer(tankInfo);

        TankTemplate tankTplt = TankTemplateData.GetData(1, "EntityFactory");
        player.Avatar.Load(tankTplt.Res);

        player.Init(tankInfo.hp, tankInfo.maxHp);
    }

    public static void RemovePlayer(ulong id)
    {
        EntityModel.RemoveEntity(id);
        BattleModel.RemovePlayer(id);
    }
}
