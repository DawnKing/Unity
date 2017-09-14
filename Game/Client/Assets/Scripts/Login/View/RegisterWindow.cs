using Common.Network;
using GameCore;
using GameProtocol;
using Login;

namespace Assets.Scripts.Login.View
{
    public sealed class RegisterWindow : WindowExtend
    {
        public UIRegister Frame { get { return contentPane as UIRegister; } }

        protected override void OnShown()
        {
            Frame.BtnRegister.onClick.Add(OnClickRegister);
        }

        private void OnClickRegister()
        {
            var account = Frame.TxtAccount.text;
            var password = Frame.TxtPassword.text;

            var request = new RequestRegister
            {
                Account = account,
                Password = password
            };
            NetMessage.Send(MessageType.RequestRegister, request, this);
        }
    }
}