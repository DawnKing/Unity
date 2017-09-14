public sealed class LoginModel
{
    #region Inst
    private static readonly LoginModel Instant = new LoginModel();
    static LoginModel() { }
    private LoginModel() { }
    public static LoginModel Inst { get { return Instant; } }
    #endregion

    // 登录服务器
    public string LoginIp;
    public int LoginPort;
    // 网管服务器
    public string GateIp;
    public int GatePort;
    // 聊天服务器
    public string ChatIp;
    public int CharPort;

    public uint SessionKey; // 服务端使用的KEY   
    public uint AccountId;  // 账号ID
}
