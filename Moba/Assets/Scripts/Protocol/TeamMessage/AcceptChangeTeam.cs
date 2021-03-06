// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TeamMessage
{
    /// 接受团员邀请
    public sealed class AcceptChangeTeam : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_ACCEPT_CHANGE_TEAM;
        public short GetMsgType { get { return MsgType; } }
        public uint TeamId;// 战队id
        public string charUuid;// 发起者 Uuid
        
        public static void Send(uint teamId, string charUuid, object className)
        {
            var packet = new AcceptChangeTeam
            {
                TeamId = teamId,
                charUuid = charUuid
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
            TeamId = reader.ReadUInt32();
            charUuid = reader.ReadString();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(TeamId);
            writer.Write(charUuid);
        }
    }
}
