// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

using GameProtocol.BulkDataType;
namespace GameProtocol.YCardMessage
{
    // 通知佣兵卡信息
    public sealed class NotifyYCardInfo : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_YCARD_INFO;
        public short GetMsgType { get { return MsgType; } }
        public YCARD_INFO[] yCardVec;// 所有佣兵卡信息
        
        public static void Send(YCARD_INFO[] yCardVec, object className)
        {
            var packet = new NotifyYCardInfo
            {
                yCardVec = yCardVec
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
            yCardVec = new YCARD_INFO[length1];
            for (var i1 = 0; i1 < length1; i1++)
            {
                yCardVec[i1] = new YCARD_INFO();
                yCardVec[i1].ReadFromStream(reader);
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            ushort count1 = (ushort)(yCardVec == null ? 0 : yCardVec.Length);
            writer.Write(count1);
            for(var i1 = 0; i1 < count1; i1++)
            {
                yCardVec[i1].WriteToStream(writer);
            }
        }
    }
}