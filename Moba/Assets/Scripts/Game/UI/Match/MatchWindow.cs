using FairyGUI;
using GameCore;
using GameProtocol.BulkDataEnum;
using GameProtocol.RoomMessage;
using PiPei;

public sealed class MatchWindow : WindowExtend
{
    public UIMatch Frame { get { return contentPane as UIMatch; } }

    protected override void OnShown()
    {
        Frame.BtnMatch.onClick.Add(OnClickMatch);
    }

    private void OnClickMatch(EventContext context)
    {
        if (MatchModel.IsMatch)
            return;

        if (NetMessage.NetConnection != null)
        {
            RequestStartMatch.Send(ROOM_TYPE.ROOM_PVP, this);
        }
        else
        {
            SceneTool.ChangeScene(SceneTool.Battle);
        }
    }

    public override void AddMessage()
    {
        Msg.Add(MsgType.StartMatch, OnStartMatch);
        Msg.Add(MsgType.StopMatch, OnStopMatch);

        base.AddMessage();
    }

    private void OnStartMatch(object obj)
    {
        Frame.c1.SetSelectedPage("Matching");
    }

    private void OnStopMatch(object obj)
    {
        Frame.c1.SetSelectedPage("StartMatch");
    }
}