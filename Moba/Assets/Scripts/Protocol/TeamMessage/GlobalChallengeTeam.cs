// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TeamMessage
{
    // MSGTYPE_DECLARE(MSG_GLOBAL_LEAGUE_CHALLENGE_TEAM),
    // 联赛请求约战Track->Global
    public sealed class GlobalChallengeTeam : IProtocol
    {
        public const short MsgType = MessageType.MSG_GLOBAL_LEAGUE_CHALLENGE_TEAM;
        public short GetMsgType { get { return MsgType; } }
        public uint TeamId;// 挑战的对方战队
        public uint Contest;// 联赛对阵标识
        public TeamBrief selfBrief;// 本方战队信息
        
        public static void Send(uint teamId, uint contest, TeamBrief selfBrief, object className)
        {
            var packet = new GlobalChallengeTeam
            {
                TeamId = teamId,
                Contest = contest,
                selfBrief = selfBrief
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
            Contest = reader.ReadUInt32();
            selfBrief = new TeamBrief();
            selfBrief.ReadFromStream(reader);
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(TeamId);
            writer.Write(Contest);
            selfBrief.WriteToStream(writer);
        }
    }
}