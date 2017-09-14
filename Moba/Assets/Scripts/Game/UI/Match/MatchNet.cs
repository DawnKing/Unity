using GameProtocol.RoomMessage;
using GameProtocol.SceneMessage;
using GameProtocol.TalentMessage;

public sealed class MatchNet : BaseNet
{
    public MatchNet()
    {
        AddMessage();
    }

    public override void AddMessage()
    {
        Msg.Add(typeof(NotifyStartMatch), OnNotifyStartMatch);   // 通知开始配对倒计时
        Msg.Add(typeof(NotifyStopMatch), OnNotifyStopMatch);   // 通知停止配对倒计时

        Msg.Add(typeof(NotifyPairSceneStart), OnNotifyPairSceneStart);  // 通知匹配赛开始

        Msg.Add(typeof(NotifyStartGame), OnNotifyStartGame);   // 成功进入房间，开始游戏

        base.AddMessage();
    }

    private void OnNotifyStartGame(IProtocol obj)
    {
        var notify = (NotifyStartGame)obj;
        BattleModel.SceneId = notify.SceneId;

        SceneTool.ChangeScene(SceneTool.Battle);
    }

    private void OnNotifyPairSceneStart(IProtocol obj)
    {
        var notify = (NotifyPairSceneStart)obj;
        MatchModel.Inst.SceneId = notify.SceneId;

        // 422请求天赋页操作
        RequestOpTalentPage.Send(TALENT_OP_TYPE.OP_ALL_PAGE, "", "", this);
        // 614Client通知track玩家锁定坦克
        RequestLockTank.Send(MatchModel.Inst.SceneId, this);
    }

    private void OnNotifyStartMatch(IProtocol obj)
    {
//        var notify = (NotifyStartMatch)obj;

        MatchModel.IsMatch = true;

        Message.Send(MsgType.StartMatch);
    }

    private void OnNotifyStopMatch(IProtocol obj)
    {
//        var notify = (NotifyStopMatch)obj;

        MatchModel.IsMatch = false;

        Message.Send(MsgType.StopMatch);
    }
}
