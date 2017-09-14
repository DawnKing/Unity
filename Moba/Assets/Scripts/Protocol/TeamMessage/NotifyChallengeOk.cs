// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TeamMessage
{
    // 通知约战成功
    public sealed class NotifyChallengeOk : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_CHALLENGE_OK;
        public short GetMsgType { get { return MsgType; } }
        public TeamBrief teamBrief;// 敌方战队信息
        public uint StartTime;// 战斗开始时间戳
        public uint RoomType;// ROOM_TYPE的排位赛和联赛的枚举
        
        public static void Send(TeamBrief teamBrief, uint startTime, uint roomType, object className)
        {
            var packet = new NotifyChallengeOk
            {
                teamBrief = teamBrief,
                StartTime = startTime,
                RoomType = roomType
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
            teamBrief = new TeamBrief();
            teamBrief.ReadFromStream(reader);
            StartTime = reader.ReadUInt32();
            RoomType = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            teamBrief.WriteToStream(writer);
            writer.Write(StartTime);
            writer.Write(RoomType);
        }
    }
}