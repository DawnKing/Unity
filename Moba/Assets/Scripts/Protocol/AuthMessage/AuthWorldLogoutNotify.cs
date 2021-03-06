// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.AuthMessage
{
    /**
     * 通知客户端正在取 
     * MSGTYPE_DECLARE(MSG_WORLD_LOGOUT_NOTIFY)				
     */
    public sealed class AuthWorldLogoutNotify : IProtocol
    {
        public const short MsgType = MessageType.MSG_WORLD_LOGOUT_NOTIFY;
        public short GetMsgType { get { return MsgType; } }
        public uint cooling;// 正式退出前的冷却时间，单位秒
        
        public static void Send(uint cooling, object className)
        {
            var packet = new AuthWorldLogoutNotify
            {
                cooling = cooling
            };
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
            cooling = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(cooling);
        }
    }
}
