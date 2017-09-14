using Assets.Scripts.Base.Network;
using Common;
using Common.Network;
using GameProtocol;
using Google.Protobuf;

namespace Assets.Scripts.Global
{
    public sealed class PingNet : BaseNet
    {
        public PingNet()
        {
            AddMessage(MessageType.NotifyPing, typeof(NotifyPing), OnNotifyPing);
        }

        private void OnNotifyPing(IMessage obj)
        {
            var notify = (NotifyPing)obj;
            Log.Write(notify.Time, typeof(PingNet));
        }
    }
}