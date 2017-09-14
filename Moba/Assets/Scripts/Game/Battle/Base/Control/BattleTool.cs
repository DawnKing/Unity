using GameProtocol.SceneMessage;
using UnityEngine;

public static class BattleTool
{
    public static bool IsSelfCamp(ulong entityId)
    {
        var selfInfo = BattleModel.GetSelfPlayerInfo();
        if (selfInfo == null)
        {
            Debug.LogWarning("selfInfo == null");
            return false;
        }
        var otherInfo = BattleModel.GetPlayerInfo(entityId);
        if (otherInfo == null)
        {
            Debug.LogWarning("otherInfo == null" + entityId);
            return false;
        }
        return selfInfo.Camp == otherInfo.Camp;
    }

    public static void AddMoveList(ulong id, float fromX, float fromZ, float toX, float toZ, float direction, float speed)
    {
        EntityMoveHandler(id);
        EntityModel.AddMoveList(id, fromX, fromZ, toX, toZ, direction, speed);
    }

    private static void EntityMoveHandler(ulong id)
    {
        var entity = EntityModel.GetMovable(id);
        Debug.Assert(entity != null, id);
        entity.MovableAvatar.BeginMove();
    }

    internal static void AddMove(ulong id, float fromX, float fromZ, float toX, float toZ, float direction, float speed)
    {
        EntityMoveHandler(id);
        EntityModel.AddMove(id, fromX, fromZ, toX, toZ, direction, speed);
    }

    public static void AddMoveList(ulong id, float fromX, float fromZ, byte direction, float speed)
    {
        if (direction == DirectionType.NONE)
        {
            EntityModel.RemoveMove(id);
            var entity = EntityModel.GetEntity(id);
            entity.Data.X = fromX;
            entity.Data.Z = fromZ;
            return;
        }

        float radian = CMath.DirectionToAngle(direction) * Mathf.Deg2Rad;
        float toX = 0;
        float toZ = 0;

        switch (direction)
        {
            case DirectionType.UP:
                toX = fromX;
                toZ = fromZ + CMath.Grid;
                break;
            case DirectionType.DOWN:
                toX = fromX;
                toZ = fromZ - CMath.Grid;
                break;
            case DirectionType.LEFT:
                toX = fromX - CMath.Grid;
                toZ = fromZ;
                break;
            case DirectionType.RIGHT:
                toX = fromX + CMath.Grid;
                toZ = fromZ;
                break;
            case DirectionType.UP_LEFT:
                toX = fromX - CMath.Grid;
                toZ = fromZ + CMath.Grid;
                break;
            case DirectionType.UP_RIGHT:
                toX = fromX + CMath.Grid;
                toZ = fromZ + CMath.Grid;
                break;
            case DirectionType.DOWN_LEFT:
                toX = fromX - CMath.Grid;
                toZ = fromZ - CMath.Grid;
                break;
            case DirectionType.DOWN_RIGHT:
                toX = fromX + CMath.Grid;
                toZ = fromZ - CMath.Grid;
                break;
            default:
                Debug.LogError("错误的DirectionType" + direction);
                break;
        }

        AddMoveList(id, fromX, fromZ, toX, toZ, radian, speed);
    }

    public static void AddMoveList(MoveInfo moveInfo)
    {
        if (!EntityModel.ContainersEntity(moveInfo.objId))
            return;

        var x = CMath.InchToMeterX(moveInfo.x);
        var y = CMath.InchToMeterZ(moveInfo.y);
        var speed = CMath.InchToMeter(moveInfo.speed);
        AddMoveList(moveInfo.objId, x, y, moveInfo.direction, speed);
    }

    public static void RemoveMove(ulong id)
    {
        var entity = EntityModel.GetMovable(id);
        Debug.Assert(entity != null);
        entity.MovableAvatar.EndMove();

        EntityModel.RemoveMove(id);
    }
}