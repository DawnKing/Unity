// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

using GameProtocol.TeamMessage;
namespace GameProtocol.LeagueMessage
{
    // MSGTYPE_DECLARE(MSG_GLOBAL_SYNC_TEAM),
    // 通知发放联赛的战队个人奖励
    public sealed class LeagueGlobalSyncTeamData : IProtocol
    {
        public const short MsgType = MessageType.MSG_GLOBAL_SYNC_TEAM;
        public short GetMsgType { get { return MsgType; } }
        public uint Cluster;// 所在区服
        public TeamInfo teamInfo;// 战队信息
        
        public static void Send(uint cluster, TeamInfo teamInfo, object className)
        {
            var packet = new LeagueGlobalSyncTeamData
            {
                Cluster = cluster,
                teamInfo = teamInfo
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
            Cluster = reader.ReadUInt32();
            teamInfo = new TeamInfo();
            teamInfo.ReadFromStream(reader);
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(Cluster);
            teamInfo.WriteToStream(writer);
        }
    }
}