// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

using GameProtocol.ShareTypes;
namespace GameProtocol.MasterPrenticeMessage
{
    // MSGTYPE_DECLARE(MSG_NOTIFY_RECEIVE_MP_APPLY),
    // 通知角色收到师徒申请
    public sealed class NotifyReceiveMPApply : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_RECEIVE_MP_APPLY;
        public short GetMsgType { get { return MsgType; } }
        public BUDDY_BRIEF Buddy;// 申请者信息
        public uint ApplyType;// 申请类型 MP_APPLY_TYPE
        
        public static void Send(BUDDY_BRIEF buddy, uint applyType, object className)
        {
            var packet = new NotifyReceiveMPApply
            {
                Buddy = buddy,
                ApplyType = applyType
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
            Buddy = new BUDDY_BRIEF();
            Buddy.ReadFromStream(reader);
            ApplyType = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            Buddy.WriteToStream(writer);
            writer.Write(ApplyType);
        }
    }
}
