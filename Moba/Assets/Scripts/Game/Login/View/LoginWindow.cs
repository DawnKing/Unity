using DengLu;
using GameCore;

public sealed class LoginWindow : WindowExtend
{
    public UILogin Frame { get { return contentPane as UILogin; } }

    protected override void OnShown()
    {
        Frame.BtnLogin.onClick.Add(OnClickLogin);
    }

    private void OnClickLogin()
    {
        if (Core.Inst.UseNet)
        {
            LoginModel.Inst.LoginIp = "10.1.1.102";
            LoginModel.Inst.LoginPort = 49119;
            LoginNet.Inst.Connect();
        }
        else
        {
            SceneTool.ChangeScene(SceneTool.MainUI);
        }
    }

    public override void AddMessage()
    {
        Msg.Add(MsgType.WorldEnterConfirm, OnWorldEnterConfirm);

        base.AddMessage();
    }

    private void OnWorldEnterConfirm(object obj)
    {
    }
}