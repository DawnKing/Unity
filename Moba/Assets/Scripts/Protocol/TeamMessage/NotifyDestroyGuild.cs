// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TeamMessage
{
    // MSGTYPE_DECLARE(MSG_NOTIFY_DESTROY_GUILD),
    // 通知解散战队
    public sealed class NotifyDestroyGuild : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_DESTROY_GUILD;
        public short GetMsgType { get { return MsgType; } }
        public uint Guild;// 军团id
        
        public static void Send(uint guild, object className)
        {
            var packet = new NotifyDestroyGuild
            {
                Guild = guild
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
            Guild = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(Guild);
        }
    }
}
