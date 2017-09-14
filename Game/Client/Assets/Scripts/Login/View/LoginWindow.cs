using Assets.Scripts.Base.Core;
using Common.Network;
using GameCore;
using GameProtocol;
using Login;

namespace Assets.Scripts.Login.View
{
    public sealed class LoginWindow : WindowExtend
    {
        public UILogin Frame { get { return contentPane as UILogin; } }

        protected override void OnShown()
        {
            Frame.BtnLogin.onClick.Add(OnClickLogin);
            Frame.BtnRegister.onClick.Add(OnClickRegister);
        }

        private void OnClickLogin()
        {
            var account = Frame.TxtAccount.text;
            var password = Frame.TxtPassword.text;

            if (Core.Inst.UseNet)
            {
                NetMessage.Send(MessageType.RequestAuthLogin,
                    new RequestLogin {Account = account, Password = password}, this);
            }
            else
            {
                SceneTool.ChangeScene(SceneTool.Battle);
            }
        }

        private void OnClickRegister()
        {
            WindowManager.Close((int)WindowId.Login);
            WindowManager.Open((int)WindowId.Register);
        }
    }
}