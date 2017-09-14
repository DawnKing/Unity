// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ItemMessage
{
    public sealed class NotifyCurCrystalSchemeIdMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_CUR_CRYSTAL_SCHEME_ID;
        public short GetMsgType { get { return MsgType; } }
        public uint schemeId;/// 晶片方案ID
        
        public static void Send(uint schemeId, object className)
        {
            var packet = new NotifyCurCrystalSchemeIdMessage
            {
                schemeId = schemeId
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
            schemeId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(schemeId);
        }
    }
}
