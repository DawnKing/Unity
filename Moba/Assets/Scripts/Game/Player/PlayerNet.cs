using GameProtocol.CharMessage;
using GameProtocol.SystemMessage;

public sealed class PlayerNet : BaseNet
{
    public PlayerNet()
    {
        AddMessage();
    }

    public override void AddMessage()
    {
        Msg.Add(typeof(NotifyCharData), OnNotifyCharData);    // 通知玩家数据
        Msg.Add(typeof(NotifyUpdateCharData), OnUpdateCharData);   // 通知同步角色数据

        base.AddMessage();
    }

    private void OnNotifyCharData(IProtocol obj)
    {
        var notify = (NotifyCharData)obj;
        PlayerModel.Inst.InitData(notify);

        GmCommand.Send("setlimit 20 0", PlayerModel.Inst.PlayerName, this);
    }

    private void OnUpdateCharData(IProtocol obj)
    {
//        var notify = (NotifyUpdateCharData)obj;
    }
}
