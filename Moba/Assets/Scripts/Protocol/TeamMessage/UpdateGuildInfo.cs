// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TeamMessage
{
    // 更新军团信息
    public sealed class UpdateGuildInfo : IProtocol
    {
        public const short MsgType = MessageType.MSG_UPDATE_GUILD_INFO;
        public short GetMsgType { get { return MsgType; } }
        public GuildInfo info;// 军团信息
        public uint Type;// UPDATE_GUILD_TYPE
        
        public static void Send(GuildInfo info, uint type, object className)
        {
            var packet = new UpdateGuildInfo
            {
                info = info,
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
            info = new GuildInfo();
            info.ReadFromStream(reader);
            Type = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            info.WriteToStream(writer);
            writer.Write(Type);
        }
    }
}
