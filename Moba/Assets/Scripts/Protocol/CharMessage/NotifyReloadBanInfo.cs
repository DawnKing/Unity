// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.CharMessage
{
    /// 通过global转发给track重新加载被举报人的封禁信息
    public sealed class NotifyReloadBanInfo : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_RELOAD_BAN_INFO;
        public short GetMsgType { get { return MsgType; } }
        public uint CheckerOid;
        public byte Type;//0 表示重新加载, 1表示踢下线
        
        public static void Send(uint checkerOid, byte type, object className)
        {
            var packet = new NotifyReloadBanInfo
            {
                CheckerOid = checkerOid,
                Type = type
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
            CheckerOid = reader.ReadUInt32();
            Type = reader.ReadByte();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(CheckerOid);
            writer.Write(Type);
        }
    }
}
