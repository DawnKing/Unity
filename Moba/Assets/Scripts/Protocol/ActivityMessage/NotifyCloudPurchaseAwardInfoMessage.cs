// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ActivityMessage
{
    /// 通知云购大奖信息
    public sealed class NotifyCloudPurchaseAwardInfoMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_CLOUD_PURCHASE_AWARD_INFO;
        public short GetMsgType { get { return MsgType; } }
        public CloudPurchaseAwardInfo[] awardInfoVec;//  云购大奖信息
        
        public static void Send(CloudPurchaseAwardInfo[] awardInfoVec, object className)
        {
            var packet = new NotifyCloudPurchaseAwardInfoMessage
            {
                awardInfoVec = awardInfoVec
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
            awardInfoVec = new CloudPurchaseAwardInfo[length1];
            for (var i1 = 0; i1 < length1; i1++)
            {
                awardInfoVec[i1] = new CloudPurchaseAwardInfo();
                awardInfoVec[i1].ReadFromStream(reader);
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            ushort count1 = (ushort)(awardInfoVec == null ? 0 : awardInfoVec.Length);
            writer.Write(count1);
            for(var i1 = 0; i1 < count1; i1++)
            {
                awardInfoVec[i1].WriteToStream(writer);
            }
        }
    }
}
