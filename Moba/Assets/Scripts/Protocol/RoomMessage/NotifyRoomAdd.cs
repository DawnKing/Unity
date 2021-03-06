// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

using GameProtocol.BulkDataType;
namespace GameProtocol.RoomMessage
{
    // MSGTYPE_DECLARE(MSG_NOTIFY_ROOM_ADD),
    // 通知客户端，有新角色加入房间
    public sealed class NotifyRoomAdd : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_ROOM_ADD;
        public short GetMsgType { get { return MsgType; } }
        public CHAR_BRIEF charData;// 新成员数据
        
        public static void Send(CHAR_BRIEF charData, object className)
        {
            var packet = new NotifyRoomAdd
            {
                charData = charData
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
            charData = new CHAR_BRIEF();
            charData.ReadFromStream(reader);
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            charData.WriteToStream(writer);
        }
    }
}
