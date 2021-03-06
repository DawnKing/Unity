// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

using GameProtocol.BulkDataType;
namespace GameProtocol.ChapterMessage
{
    // 通知客户端，更新城市信息
    public sealed class UpdateCityInfo : IProtocol
    {
        public const short MsgType = MessageType.MSG_UPDATE_CITY_INFO;
        public short GetMsgType { get { return MsgType; } }
        public CITY_INFO[] infoVec;
        
        public static void Send(CITY_INFO[] infoVec, object className)
        {
            var packet = new UpdateCityInfo
            {
                infoVec = infoVec
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
            var length1 = reader.ReadUInt16();
            infoVec = new CITY_INFO[length1];
            for (var i1 = 0; i1 < length1; i1++)
            {
                infoVec[i1] = new CITY_INFO();
                infoVec[i1].ReadFromStream(reader);
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            ushort count1 = (ushort)(infoVec == null ? 0 : infoVec.Length);
            writer.Write(count1);
            for(var i1 = 0; i1 < count1; i1++)
            {
                infoVec[i1].WriteToStream(writer);
            }
        }
    }
}
