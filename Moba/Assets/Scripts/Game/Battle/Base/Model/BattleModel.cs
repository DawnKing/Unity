using GameProtocol.TankMessage;
using System.Collections.Generic;
using UnityEngine;

public static class BattleModel
{
    // 服务端数据
    private static readonly Dictionary<uint, TankInfo> PlayerInfo = new Dictionary<uint, TankInfo>();

    // 摄像机
    public static GameObject CameraEntity; 
    public static Vector3 CameraPosition = new Vector3(0, 20, 0);

    public static uint SceneId;
    public static NotifySelfData SelfData { get; set; }
    public static SelfPlayer Self;
    public static Entity Target;

    public static void AddPlayer(TankInfo tankInfo)
    {
        if (PlayerInfo.ContainsKey(tankInfo.acctOid))
        {
            Debug.LogWarning("已经存在坦克" + tankInfo.acctOid);
            return;
        }
        PlayerInfo.Add(tankInfo.acctOid, tankInfo);
    }

    public static void RemovePlayer(ulong id)
    {
        RemovePlayer((uint)id);
    }

    public static void RemovePlayer(uint objId)
    {
        PlayerInfo.Remove(objId);
    }

    public static void UpdatePlayer(TankInfo tankInfo)
    {
        PlayerInfo[tankInfo.acctOid] = tankInfo;
    }

    public static bool ContainsPlayer(ulong id)
    {
        return ContainsPlayer((uint)id);
    }

    public static bool ContainsPlayer(uint objId)
    {
        return PlayerInfo.ContainsKey(objId);
    }

    public static TankInfo GetPlayerInfo(ulong id)
    {
        return GetPlayerInfo((uint)id);
    }

    public static TankInfo GetPlayerInfo(uint objId)
    {
        if (!PlayerInfo.ContainsKey(objId))
            return null;
        return PlayerInfo[objId];
    }

    public static TankInfo GetSelfPlayerInfo()
    {
        if (Self == null)
            return null;
        return GetPlayerInfo(Self.Id);
    }
}