// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TeamMessage
{
    // 通知平台赛事接口比赛结果
    public sealed class NotifyRemotePlatformMatchResult : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_REMOTE_PLATFORM_MATCH_RESULT;
        public short GetMsgType { get { return MsgType; } }
        public byte Win;// 是否获胜
        public uint RoomType;// 房间类型
        public uint TeamId;// 战队ID
        public uint SessionId;// 联赛需要传递sessionID
        public string strLeagueName;// 赛事名称
        public string strMatchName;// 赛事轮次名称
        public uint Policy;// 赛事策略
        public uint AnnounceType;// 赛事公告类型 enum LEAGUE_ANNOUNCE_TYPE
        public string strEnemyName;// 对手名称
        public int Place;// 队伍名次
        
        public static void Send(byte win, uint roomType, uint teamId, uint sessionId, string strLeagueName, string strMatchName, uint policy, uint announceType, string strEnemyName, int place, object className)
        {
            var packet = new NotifyRemotePlatformMatchResult
            {
                Win = win,
                RoomType = roomType,
                TeamId = teamId,
                SessionId = sessionId,
                strLeagueName = strLeagueName,
                strMatchName = strMatchName,
                Policy = policy,
                AnnounceType = announceType,
                strEnemyName = strEnemyName,
                Place = place
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
            Win = reader.ReadByte();
            RoomType = reader.ReadUInt32();
            TeamId = reader.ReadUInt32();
            SessionId = reader.ReadUInt32();
            strLeagueName = reader.ReadString();
            strMatchName = reader.ReadString();
            Policy = reader.ReadUInt32();
            AnnounceType = reader.ReadUInt32();
            strEnemyName = reader.ReadString();
            Place = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(Win);
            writer.Write(RoomType);
            writer.Write(TeamId);
            writer.Write(SessionId);
            writer.Write(strLeagueName);
            writer.Write(strMatchName);
            writer.Write(Policy);
            writer.Write(AnnounceType);
            writer.Write(strEnemyName);
            writer.Write(Place);
        }
    }
}
