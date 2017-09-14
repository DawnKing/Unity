// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.CharMessage
{
    // 通知角色显示的荣誉
    public sealed class NotifyHonor : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_HONOR;
        public short GetMsgType { get { return MsgType; } }
        public uint honorID;// 荣誉id
        
        public static void Send(uint honorID, object className)
        {
            var packet = new NotifyHonor
            {
                honorID = honorID
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
            honorID = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(honorID);
        }
    }
}
