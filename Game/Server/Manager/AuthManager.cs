using Common.Network;
using GameProtocol;

namespace Server.Manager
{
    public static class AuthManager
    {
        public static void Start()
        {
            NetMessage.AddListener(MessageType.RequestRegister, OnRequestRegister);
            NetMessage.AddListener(MessageType.RequestAuthLogin, OnRequestAuthLogin);
        }

        private static void OnRequestRegister(ProtocolMessage message, uint id)
        {
            var request = RequestRegister.Parser.ParseFrom(message.Data);
            DatabaseManager.Register(request.Account, request.Password);
        }

        private static void OnRequestAuthLogin(ProtocolMessage message, uint clientId)
        {
            var request = RequestLogin.Parser.ParseFrom(message.Data);
            NotifyLogin.Types.ResultType result = DatabaseManager.Login(request.Account, request.Password);
            var notify = new NotifyLogin
            {
                Result = result
            };
            ClientManager.Send(clientId, MessageType.NotifyLogin, notify, typeof(AuthManager));
        }
    }
}