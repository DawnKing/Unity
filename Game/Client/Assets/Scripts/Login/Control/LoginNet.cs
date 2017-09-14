using Assets.Scripts.Base.Network;
using Common;
using Common.Network;
using GameProtocol;
using Google.Protobuf;

namespace Assets.Scripts.Login.Control
{
    public sealed class LoginNet : BaseNet
    {
        public LoginNet()
        {
            AddMessage(MessageType.NotifyLogin, typeof(NotifyLogin), OnNotifyLogin);
        }

        private void OnNotifyLogin(IMessage obj)
        {
            var notify = (NotifyLogin)obj;
            Log.Write("收到登陆消息" + notify.Result, this);
            switch (notify.Result)
            {
                case NotifyLogin.Types.ResultType.Success:
                    SceneTool.ChangeScene(SceneTool.Battle);
                    break;
            }
        }
    }
}
