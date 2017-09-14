using GameProtocol.AuthMessage;
using GameProtocol.LoginProtocol;
using GameProtocol.version;
using UnityEngine;

public sealed class LoginNet : BaseNet
{
    #region Inst
    private static readonly LoginNet Instant = new LoginNet();
    static LoginNet() { }
    private LoginNet() { }
    public static LoginNet Inst { get { return Instant; } }
    #endregion

    private readonly NetConnection _netConnection = new NetConnection();

    public void Connect()
    {
        if (GateNet.Inst.Connected)
            return;

        if (_netConnection.Connected)
            return;

        NetMessage.NetConnection = _netConnection;

        AddMessage();

        Debug.Log(string.Format("连接登录服务器, ip:{0}, port:{1}", LoginModel.Inst.LoginIp, LoginModel.Inst.LoginPort));
        _netConnection.OnConnected = OnConnected;
        _netConnection.Connect(LoginModel.Inst.LoginIp, LoginModel.Inst.LoginPort);
    }

    public override void Dispose()
    {
        NetMessage.NetConnection = null;
        _netConnection.Dispose();

        base.Dispose();
    }

    private void OnConnected()
    {
        Debug.Log("RequestProtocolVersion");
        RequestProtocolVersion.Send(PROTOCOL_VERSION.ZU_AUTH_NET_VERSION,
            PROTOCOL_VERSION.ZU_GAME_NET_VERSION,
            0,
            "1.0.1.8480",
            this);
    }

    public override void AddMessage()
    {
        Msg.Add(typeof(VersionOk), OnVersionOk);   // 协议版本验证通过
        Msg.Add(typeof(VersionFail), OnVersionFailed);   // 协议版本验证失败

        Msg.Add(typeof(LoginOk), OnLoginOk);  // 帐号密码验证成功
        Msg.Add(typeof(LoginFail), OnLoginFail);  // 帐号密码验证失败
        Msg.Add(typeof(SessionRequestReject), OnLoginReject); // 帐号登录被拒绝

        Msg.Add(typeof(RegionServerList), OnServerList);    //通知网关服务器信息

        base.AddMessage();
    }

    private void OnServerList(IProtocol obj)
    {
        var notify = (RegionServerList)obj;
        var regionInfo = notify.regions[0];

        LoginModel.Inst.GateIp = regionInfo.gate_realm;
        LoginModel.Inst.GatePort = regionInfo.gate_port;

        LoginModel.Inst.ChatIp = regionInfo.comrealm;
        LoginModel.Inst.CharPort = regionInfo.comport;

        Dispose();
        GateNet.Inst.Connect();
    }

    private void OnLoginOk(IProtocol obj)
    {
        var notify = (LoginOk)obj;
        LoginModel.Inst.SessionKey = notify.sessionkey;
        LoginModel.Inst.AccountId = notify.AcctId;
        Debug.Log(string.Format("OnLoginOk, SessionKey:{0}, AccountId:{1}", notify.sessionkey, notify.AcctId));
    }

    private void OnLoginFail(IProtocol obj)
    {
        var notify = (LoginFail)obj;
        var value = notify.reason;

        string message = "";
        string loginResult = "";
        switch (value)
        {
            case AUTH_RESULT.AUTH_RESULT_USER_ID_NO_EXIST:     //账号错误
            case AUTH_RESULT.AUTH_RESULT_NAME_PASSWORD_ERROR:   //密码错
            case AUTH_RESULT.AUTH_RESULT_ACCOUNT_ID_ERR:   //账号id不存在
                message = GameText.LF_TXT01;
                loginResult = "account or password fail";
                break;
            case AUTH_RESULT.AUTH_RESULT_SVRCONNECT:           //无法连接认证服务
                message = GameText.LF_TXT03;
                loginResult = "AUTH_RESULT_SVRCONNECT";
                break;
            case AUTH_RESULT.AUTH_RESULT_HTTPERROR:            //http认证服务返回不合法信息
                message = GameText.LF_TXT04;
                loginResult = "AUTH_RESULT_HTTPERROR";
                break;
            case AUTH_RESULT.AUTH_RESULT_SVRFULL:              //服务器满
                message = GameText.LF_TXT02;
                loginResult = "AUTH_RESULT_SVRFULL";
                break;
            case AUTH_RESULT.AUTH_RESULT_UNKNOWN:              //未知错误
                message = GameText.LF_TXT05;
                loginResult = "AUTH_RESULT_UNKNOWN";
                break;
            case AUTH_RESULT.AUTH_RESULT_ACCOUNT_CLOSED:                    //该帐号被封存
                message = GameText.LF_TXT07;
                loginResult = "AUTH_RESULT_ACCOUNT_CLOSED";
                break;
            case AUTH_RESULT.AUTH_RESULT_WALLOW_TIME:                       //帐号被防沉迷
                message = GameText.LF_TXT06;
                loginResult = "AUTH_RESULT_WALLOW_TIME";
                break;
            case AUTH_RESULT.AUTH_WAO_TOKEN_NONE:
                message = GameText.LF_TXT08;
                loginResult = "AUTH_WAO_TOKEN_NONE";
                break;
            case AUTH_RESULT.AUTH_WAO_TOKEN_TIMEOUT:   //时间戳过期
                message = GameText.LF_TXT10;
                loginResult = "AUTH_WAO_TOKEN_TIMEOUT";
                break;
            case AUTH_RESULT.AUTH_RESULT_FAILD:
                message = GameText.LF_TXT09;
                loginResult = "AUTH_RESULT_FAILD";
                break;
            case AUTH_RESULT.AUTH_RESULT_MAINTENANCE:    //服务器未开放
                loginResult = "AUTH_RESULT_MAINTENANCE";
                break;
            case AUTH_RESULT.AUTH_RESULT_BAN_IP:    //IP被封存 
                message = GameText.LF_TXT12;
                loginResult = "AUTH_RESULT_BAN_IP";
                break;
            case AUTH_RESULT.AUTH_RESULT_COUNTRY_ERR:       //登录IP超出授权范围
                message = GameText.LF_TXT13;
                break;
            case AUTH_RESULT.AUTH_RESULT_PARAM_LACK:   //参数不完整
                message = GameText.LF_TXT17;
                break;
            default:
                message = "未处理的登录失败类型: " + value;
                loginResult = "unhandle fail " + value;
                break;
        }

        Debug.LogWarning(message + loginResult);
    }

    private void OnLoginReject(IProtocol obj)
    {
        Debug.LogWarning("登录被拒绝");
    }

    private void OnVersionOk(IProtocol obj)
    {
        RequestAuthLogin.Send(0, "test01", "1", "", "", "", "", "", "", 0, this);
    }

    private void OnVersionFailed(IProtocol obj)
    {
        var notify = (VersionFail)obj;
        Debug.LogWarning("验证失败"+notify.reason);
    }
}
