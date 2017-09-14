// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.LeagueMessage
{
    // MSGTYPE_DECLARE(MSG_LEAGUE_STOP_PAIR),
    // 请求停止联赛匹配
    public sealed class LeagueStopPair : IProtocol
    {
        public const short MsgType = MessageType.MSG_LEAGUE_STOP_PAIR;
        public short GetMsgType { get { return MsgType; } }
        public uint TeamId;// 战队id
        
        public static void Send(uint teamId, object className)
        {
            var packet = new LeagueStopPair
            {
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
            TeamId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(TeamId);
        }
    }
}