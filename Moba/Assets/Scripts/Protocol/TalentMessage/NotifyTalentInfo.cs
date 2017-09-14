// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

using GameProtocol.BulkDataType;
namespace GameProtocol.TalentMessage
{
    // 通知天赋信息
    public sealed class NotifyTalentInfo : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_TALENT_INFO;
        public short GetMsgType { get { return MsgType; } }
        public TALENT_PAGE[] talentPageVec;// 所有天赋页信息
        public uint talTotalPoint;// 天赋总可用点数
        
        public static void Send(TALENT_PAGE[] talentPageVec, uint talTotalPoint, object className)
        {
            var packet = new NotifyTalentInfo
            {
                talentPageVec = talentPageVec,
                talTotalPoint = talTotalPoint
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
            talentPageVec = new TALENT_PAGE[length1];
            for (var i1 = 0; i1 < length1; i1++)
            {
                talentPageVec[i1] = new TALENT_PAGE();
                talentPageVec[i1].ReadFromStream(reader);
            }
            talTotalPoint = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            ushort count1 = (ushort)(talentPageVec == null ? 0 : talentPageVec.Length);
            writer.Write(count1);
            for(var i1 = 0; i1 < count1; i1++)
            {
                talentPageVec[i1].WriteToStream(writer);
            }
            writer.Write(talTotalPoint);
        }
    }
}
