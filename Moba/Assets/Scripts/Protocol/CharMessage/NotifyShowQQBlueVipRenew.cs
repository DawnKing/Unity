// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.CharMessage
{
    // MSGTYPE_DECLARE(MSG_NOTIFY_SHOW_QQ_BLUE_VIP_RENEW)
    public sealed class NotifyShowQQBlueVipRenew : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_SHOW_QQ_BLUE_VIP_RENEW;
        public short GetMsgType { get { return MsgType; } }
        public uint BlueEndTime;// 蓝钻结束时间
        public uint BlueYearEndTime;// 年费蓝钻结束时间
        public uint SuperBlueEndTime;// 豪华蓝钻结束时间
        public uint ExpandBlueEndTime;// 超级蓝钻结束时间
        public uint SvrTime;// 服务器时间
        
        public static void Send(uint blueEndTime, uint blueYearEndTime, uint superBlueEndTime, uint expandBlueEndTime, uint svrTime, object className)
        {
            var packet = new NotifyShowQQBlueVipRenew
            {
                BlueEndTime = blueEndTime,
                BlueYearEndTime = blueYearEndTime,
                SuperBlueEndTime = superBlueEndTime,
                ExpandBlueEndTime = expandBlueEndTime,
                SvrTime = svrTime
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
            BlueEndTime = reader.ReadUInt32();
            BlueYearEndTime = reader.ReadUInt32();
            SuperBlueEndTime = reader.ReadUInt32();
            ExpandBlueEndTime = reader.ReadUInt32();
            SvrTime = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(BlueEndTime);
            writer.Write(BlueYearEndTime);
            writer.Write(SuperBlueEndTime);
            writer.Write(ExpandBlueEndTime);
            writer.Write(SvrTime);
        }
    }
}
