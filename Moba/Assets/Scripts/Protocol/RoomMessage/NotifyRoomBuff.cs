// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.RoomMessage
{
    // MSGTYPE_DECLARE(MSG_NOTIFY_ROOM_BUFF),
    // 通知房间buff信息
    public sealed class NotifyRoomBuff : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_ROOM_BUFF;
        public short GetMsgType { get { return MsgType; } }
        public uint CharId;// 角色id
        public uint[] BuffVec;// 角色buff列表
        
        public static void Send(uint charId, uint[] buffVec, object className)
        {
            var packet = new NotifyRoomBuff
            {
                CharId = charId,
                BuffVec = buffVec
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
            CharId = reader.ReadUInt32();
            var length2 = reader.ReadUInt16();
            BuffVec = new uint[length2];
            for (var i2 = 0; i2 < length2; i2++)
            {
                BuffVec[i2] = reader.ReadUInt32();
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(CharId);
            ushort count2 = (ushort)(BuffVec == null ? 0 : BuffVec.Length);
            writer.Write(count2);
            for(var i2 = 0; i2 < count2; i2++)
            {
                writer.Write(BuffVec[i2]);
            }
        }
    }
}
