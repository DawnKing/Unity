// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TankMakeMessage
{
    //一元一次夺宝
    //五元一次夺宝
    //五元十次夺宝
    // 请求夺宝
    public sealed class RequestStartTreasureMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_START_TREASURE;
        public short GetMsgType { get { return MsgType; } }
        public uint nType;// 夺宝类型 enum TREASURE_TYPE
        
        public static void Send(uint nType, object className)
        {
            var packet = new RequestStartTreasureMessage
            {
                nType = nType
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
            nType = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(nType);
        }
    }
}
