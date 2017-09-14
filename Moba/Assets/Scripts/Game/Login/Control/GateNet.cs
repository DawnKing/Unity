using GameProtocol.AuthMessage;
using GameProtocol.CharMessage;
using GameProtocol.version;
using GameProtocol.WorldMessage;
using UnityEngine;

public sealed class GateNet : BaseNet
{
    #region Inst
    private static readonly GateNet Instant = new GateNet();
    static GateNet() { }
    private GateNet() { }
    public static GateNet Inst { get { return Instant; } }
    #endregion

    private readonly NetConnection _netConnection = new NetConnection();

    public bool Connected { get; set; }

    public void Connect()
    {
        if (_netConnection.Connected)
            return;

        NetMessage.NetConnection = _netConnection;

        AddMessage();

        Debug.Log(string.Format("连接网关服务器, ip:{0}, port:{1}", LoginModel.Inst.GateIp, LoginModel.Inst.GatePort));
        _netConnection.OnConnected = OnConnected;
        _netConnection.Connect(LoginModel.Inst.GateIp, LoginModel.Inst.GatePort);
    }

    private void OnConnected()
    {
        Debug.Log("网关版本验证");
        RequestProtocolVersion.Send(
            PROTOCOL_VERSION.ZU_AUTH_NET_VERSION,
            PROTOCOL_VERSION.ZU_GAME_NET_VERSION, 
            0,
            "1.0.1.8480",
            this);
    }

    public override void AddMessage()
    {
        Msg.Add(typeof(VersionOk), OnVersionOk);   // 协议版本验证通过
        Msg.Add(typeof(CharPickApprovedMessage), OnCharPickApproved); // 允许选择角色进入游戏
        Msg.Add(typeof(WorldEnterConfirm), OnWorldEnterConfirm);  // 进入世界确认

        base.AddMessage();
    }

    private void OnVersionOk(IProtocol obj)
    {
        RequestServerLogin.Send(
            LoginModel.Inst.SessionKey,
            LoginModel.Inst.AccountId,
            this);
    }

    private void OnCharPickApproved(IProtocol obj)
    {
        var notify = (CharPickApprovedMessage)obj;
        PlayerModel.Inst.CharUuid = notify.charUuid;

        RequestEnterWorld();
    }

    private void RequestEnterWorld()
    {
        WorldEnterMessage.Send(PlayerModel.Inst.CharUuid, "", 0, "", 0, this);
    }

    private void OnWorldEnterConfirm(IProtocol obj)
    {
        Debug.Log("change scene to main ui");
        Message.Send(MsgType.WorldEnterConfirm);

        SceneTool.ChangeScene(SceneTool.MainUI);
    }
}
