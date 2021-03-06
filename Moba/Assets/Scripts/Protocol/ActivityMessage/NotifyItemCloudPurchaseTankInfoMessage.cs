// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ActivityMessage
{
    /// 通知对应物品云购奖励坦克信息
    public sealed class NotifyItemCloudPurchaseTankInfoMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_ITEM_CLOUD_PURCHASE_TANK_INFO;
        public short GetMsgType { get { return MsgType; } }
        public uint awardTime;
        public uint[] tankIdVec;//  坦克ID
        
        public static void Send(uint awardTime, uint[] tankIdVec, object className)
        {
            var packet = new NotifyItemCloudPurchaseTankInfoMessage
            {
                awardTime = awardTime,
                tankIdVec = tankIdVec
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
            awardTime = reader.ReadUInt32();
            var length2 = reader.ReadUInt16();
            tankIdVec = new uint[length2];
            for (var i2 = 0; i2 < length2; i2++)
            {
                tankIdVec[i2] = reader.ReadUInt32();
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(awardTime);
            ushort count2 = (ushort)(tankIdVec == null ? 0 : tankIdVec.Length);
            writer.Write(count2);
            for(var i2 = 0; i2 < count2; i2++)
            {
                writer.Write(tankIdVec[i2]);
            }
        }
    }
}
