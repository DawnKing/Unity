// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TankMakeMessage
{
    // 通知坦克制造信息
    public sealed class NotifyMakeTankInfo : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_MAKE_TANK_INFO;
        public short GetMsgType { get { return MsgType; } }
        public uint nLuckyVal;// 幸运值
        
        public static void Send(uint nLuckyVal, object className)
        {
            var packet = new NotifyMakeTankInfo
            {
                nLuckyVal = nLuckyVal
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
            nLuckyVal = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(nLuckyVal);
        }
    }
}
