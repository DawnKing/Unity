// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TeamMessage
{
    public sealed class NotifyRoundPassRoomMember : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_ROUNDPASS_ROOM_MEMBER_UUID;
        public short GetMsgType { get { return MsgType; } }
        public uint GuildId;
        public string[] vecUuid;
        public uint Reason;// enum REQ_MEMBER_REASON
        public ulong Id;// 军团对阵ID（军团轮空为0）
        
        public static void Send(uint guildId, string[] vecUuid, uint reason, ulong id, object className)
        {
            var packet = new NotifyRoundPassRoomMember
            {
                GuildId = guildId,
                vecUuid = vecUuid,
                Reason = reason,
                Id = id
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
            var length2 = reader.ReadUInt16();
            vecUuid = new string[length2];
            for (var i2 = 0; i2 < length2; i2++)
            {
                vecUuid[i2] = reader.ReadString();
            }
            Reason = reader.ReadUInt32();
            Id = reader.ReadUInt64();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(GuildId);
            ushort count2 = (ushort)(vecUuid == null ? 0 : vecUuid.Length);
            writer.Write(count2);
            for(var i2 = 0; i2 < count2; i2++)
            {
                writer.Write(vecUuid[i2]);
            }
            writer.Write(Reason);
            writer.Write(Id);
        }
    }
}