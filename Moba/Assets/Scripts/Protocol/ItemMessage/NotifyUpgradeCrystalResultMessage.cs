// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ItemMessage
{
    /// 通知升阶晶片结果
    public sealed class NotifyUpgradeCrystalResultMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_UPGRADE_CRYSTAL_RESULT;
        public short GetMsgType { get { return MsgType; } }
        public uint itemId;/// 生成晶片ID
        
        public static void Send(uint itemId, object className)
        {
            var packet = new NotifyUpgradeCrystalResultMessage
            {
                itemId = itemId
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
            itemId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(itemId);
        }
    }
}