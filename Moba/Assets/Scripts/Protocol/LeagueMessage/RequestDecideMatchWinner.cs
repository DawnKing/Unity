// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.LeagueMessage
{
    /// 请求设定邀请赛比赛结果
    public sealed class RequestDecideMatchWinner : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_DECIDE_MATCH_WINNER;
        public short GetMsgType { get { return MsgType; } }
        public uint CharOid;// 角色ID
        public uint ContestId;// 对阵ID
        public uint RoomId;// 房间ID
        public uint WinTeamId;// 获胜队伍ID
        public uint RedTeamScore;// 红队得分
        public uint BlueTeamScore;// 蓝队得分
        
        public static void Send(uint charOid, uint contestId, uint roomId, uint winTeamId, uint redTeamScore, uint blueTeamScore, object className)
        {
            var packet = new RequestDecideMatchWinner
            {
                CharOid = charOid,
                ContestId = contestId,
                RoomId = roomId,
                WinTeamId = winTeamId,
                RedTeamScore = redTeamScore,
                BlueTeamScore = blueTeamScore
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
            CharOid = reader.ReadUInt32();
            ContestId = reader.ReadUInt32();
            RoomId = reader.ReadUInt32();
            WinTeamId = reader.ReadUInt32();
            RedTeamScore = reader.ReadUInt32();
            BlueTeamScore = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(CharOid);
            writer.Write(ContestId);
            writer.Write(RoomId);
            writer.Write(WinTeamId);
            writer.Write(RedTeamScore);
            writer.Write(BlueTeamScore);
        }
    }
}
