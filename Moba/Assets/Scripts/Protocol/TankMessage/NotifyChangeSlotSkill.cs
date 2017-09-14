// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

using GameProtocol.BulkDataType;
namespace GameProtocol.TankMessage
{
    // MSGTYPE_DECLARE(MSG_NOTIFY_CHANGE_SLOT_SKILL),
    // 通知技能变化
    public sealed class NotifyChangeSlotSkill : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_CHANGE_SLOT_SKILL;
        public short GetMsgType { get { return MsgType; } }
        public PropsInfo itemData;// 技能信息
        
        public static void Send(PropsInfo itemData, object className)
        {
            var packet = new NotifyChangeSlotSkill
            {
                itemData = itemData
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
            itemData = new PropsInfo();
            itemData.ReadFromStream(reader);
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            itemData.WriteToStream(writer);
        }
    }
}
