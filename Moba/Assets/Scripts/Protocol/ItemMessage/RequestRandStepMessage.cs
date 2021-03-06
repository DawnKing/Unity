// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ItemMessage
{
    /// 请求冒险夺宝
    public sealed class RequestRandStepMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_RAND_STEP;
        public short GetMsgType { get { return MsgType; } }
        public byte Batch;// 是否十连抽
        
        public static void Send(byte batch, object className)
        {
            var packet = new RequestRandStepMessage
            {
                Batch = batch
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
            Batch = reader.ReadByte();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(Batch);
        }
    }
}
