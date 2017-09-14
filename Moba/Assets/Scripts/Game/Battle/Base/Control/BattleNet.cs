using GameProtocol.SceneMessage;
using GameProtocol.TankMessage;
using UnityEngine;

public sealed class BattleNet : BaseNet
{
    public BattleNet()
    {
        AddMessage();
    }

    public override void AddMessage()
    {
        Msg.Add(typeof(NotifyBattleEnter), OnNotifyBattleEnter);   // 通知进入战场

        // 玩家
        Msg.Add(typeof(NotifySelfData), OnNotifySelfData);  // 上线通知自身数据
        Msg.Add(typeof(NotifyAddTank), OnNotifyAddTank);  // 通知添加坦克
        Msg.Add(typeof(NotifyOtherList), OnNotifyOtherList);   // 上线通知其他玩家数据
        
        // 对象
        Msg.Add(typeof(NotifySceneObject), OnNotifySceneObject);   // 通知战场对象数据

        Msg.Add(typeof(SyncSceneData), OnSyncSceneData);    // 战场数据同步

        base.AddMessage();
    }

    private void OnSyncSceneData(IProtocol obj)
    {
        var notify = (SyncSceneData)obj;

        BattleScene.SceneHandler(notify);
    }

    private void OnNotifySceneObject(IProtocol obj)
    {
        //        var notify = (NotifySceneObject)obj;
    }

    private void OnNotifyAddTank(IProtocol obj)
    {
        var notify = (NotifyAddTank)obj;

        BattleEvent.Inst.AddEvent(BattleEventType.CreatePlayer, notify.selfData);
    }

    private void OnNotifyOtherList(IProtocol obj)
    {
        var notify = (NotifyOtherList)obj;

        foreach (var tankInfo in notify.otherList)
        {
            BattleEvent.Inst.AddEvent(BattleEventType.CreatePlayer, tankInfo);
        }
    }

    private void OnNotifySelfData(IProtocol obj)
    {
        var notify = (NotifySelfData)obj;

        BattleModel.SelfData = notify;
        EntityFactory.AddSelfPlayer(notify.selfData);
    }

    private void OnNotifyBattleEnter(IProtocol obj)
    {
        var notify = (NotifyBattleEnter)obj;
        Debug.Log("游戏开始"+notify.StartTime);
    }
}
