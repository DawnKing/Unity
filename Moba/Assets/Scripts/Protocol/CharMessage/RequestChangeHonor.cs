// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.CharMessage
{
    /// 请求更换荣誉
    public sealed class RequestChangeHonor : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_CHANGE_HONOR;
        public short GetMsgType { get { return MsgType; } }
        public uint HonorId;/// 请求更换的荣誉ID
        
        public static void Send(uint honorId, object className)
        {
            var packet = new RequestChangeHonor
            {
                HonorId = honorId
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
            HonorId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(HonorId);
        }
    }
}