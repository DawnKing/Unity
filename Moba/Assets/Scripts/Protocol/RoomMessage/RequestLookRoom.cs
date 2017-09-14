// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.RoomMessage
{
    // MSGTYPE_DECLARE(MSG_REQUEST_LOOK_ROOM),
    // 加入房间观战
    public sealed class RequestLookRoom : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_LOOK_ROOM;
        public short GetMsgType { get { return MsgType; } }
        public uint RoomId;// 房间id
        public byte Type;// 房间类型 enum ROOM_TYPE
        public uint ContestId;// 邀请赛需要指定对阵ID
        
        public static void Send(uint roomId, byte type, uint contestId, object className)
        {
            var packet = new RequestLookRoom
            {
                RoomId = roomId,
                Type = type,
                ContestId = contestId
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
            RoomId = reader.ReadUInt32();
            Type = reader.ReadByte();
            ContestId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(RoomId);
            writer.Write(Type);
            writer.Write(ContestId);
        }
    }
}
