// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.FriendMessage
{
    //通知隔天计算累计在线天数
    public sealed class NotifyInviteGiftCrossDayMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_INVITE_GIFT_CROSS_DAY;
        public short GetMsgType { get { return MsgType; } }
        
        public static void Send(object className)
        {
            var packet = new NotifyInviteGiftCrossDayMessage();
            NetMessage.Send(packet.BuildPacket(), className);
        }
        
        public byte[] BuildPacket()
        {
            var buffer = ProtocolBuffer.Writer;
            buffer.Write(MsgType);
            buffer.Write(ProtocolBuffer.Zero);
            WriteToStream(buffer);
            return ProtocolBuffer.CacheStream.ToArray();
        }
        
        public void ReadFromStream(BinaryReader reader)
        {
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
        }
    }
}
