// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TeamMessage
{
    // MSGTYPE_DECLARE(MSG_REQUEST_JOIN_GUILD),
    // 加入军团
    public sealed class RequestJoinGuild : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_JOIN_GUILD;
        public short GetMsgType { get { return MsgType; } }
        public uint GuildId;// 军团id
        public uint TeamId;// 战队id
        
        public static void Send(uint guildId, uint teamId, object className)
        {
            var packet = new RequestJoinGuild
            {
                GuildId = guildId,
                TeamId = teamId
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
            GuildId = reader.ReadUInt32();
            TeamId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(GuildId);
            writer.Write(TeamId);
        }
    }
}