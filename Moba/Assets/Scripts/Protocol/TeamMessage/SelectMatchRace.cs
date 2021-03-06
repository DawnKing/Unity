// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TeamMessage
{
    // MSGTYPE_DECLARE(MSG_SELECT_MATCH_RACE),
    // 战队选择参战赛事
    public sealed class SelectMatchRace : IProtocol
    {
        public const short MsgType = MessageType.MSG_SELECT_MATCH_RACE;
        public short GetMsgType { get { return MsgType; } }
        public uint matchId;// 联赛id
        public string raceUuid;// 比赛uuid
        
        public static void Send(uint matchId, string raceUuid, object className)
        {
            var packet = new SelectMatchRace
            {
                matchId = matchId,
                raceUuid = raceUuid
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
            matchId = reader.ReadUInt32();
            raceUuid = reader.ReadString();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(matchId);
            writer.Write(raceUuid);
        }
    }
}
