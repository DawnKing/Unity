// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ChapterMessage
{
    // MSGTYPE_DECLARE(MSG_SOLO_REQUEST_SWEEP_MAP),
    // 请求地图扫荡
    public sealed class RequestSweepSoloMap : IProtocol
    {
        public const short MsgType = MessageType.MSG_SOLO_REQUEST_SWEEP_MAP;
        public short GetMsgType { get { return MsgType; } }
        public uint CityId;// 扫荡的副本id
        public uint Count;// 扫荡次数
        
        public static void Send(uint cityId, uint count, object className)
        {
            var packet = new RequestSweepSoloMap
            {
                CityId = cityId,
                Count = count
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
            CityId = reader.ReadUInt32();
            Count = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(CityId);
            writer.Write(Count);
        }
    }
}
