// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.RoomMessage
{
    // MSGTYPE_DECLARE(MSG_REJECT_ROOM_INVITE),
    // 拒绝房间邀请
    public sealed class RejectRoomInvite : IProtocol
    {
        public const short MsgType = MessageType.MSG_REJECT_ROOM_INVITE;
        public short GetMsgType { get { return MsgType; } }
        public uint StartId;// 发起玩家id
        
        public static void Send(uint startId, object className)
        {
            var packet = new RejectRoomInvite
            {
                StartId = startId
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
            StartId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(StartId);
        }
    }
}
