// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.LeagueMessage
{
    public sealed class LeagueRequestAward : IProtocol
    {
        public const short MsgType = MessageType.MSG_LEAGUE_REQUEST_AWARD;
        public short GetMsgType { get { return MsgType; } }
        public uint awardId;// 奖励的ID
        
        public static void Send(uint awardId, object className)
        {
            var packet = new LeagueRequestAward
            {
                awardId = awardId
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
            awardId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(awardId);
        }
    }
}