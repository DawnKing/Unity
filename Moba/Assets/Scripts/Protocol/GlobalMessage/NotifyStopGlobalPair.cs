// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.GlobalMessage
{
    // MSGTYPE_DECLARE(MSG_GLOBAL_STOP_PAIR),
    // 停止跨服配对
    public sealed class NotifyStopGlobalPair : IProtocol
    {
        public const short MsgType = MessageType.MSG_GLOBAL_STOP_PAIR;
        public short GetMsgType { get { return MsgType; } }
        public byte Type;// 配对类型
        public uint RoomType;// 匹配的房间类型 enum ROOM_TYPE
        public uint PairId;// 配对的id
        
        public static void Send(byte type, uint roomType, uint pairId, object className)
        {
            var packet = new NotifyStopGlobalPair
            {
                Type = type,
                RoomType = roomType,
                PairId = pairId
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
            Type = reader.ReadByte();
            RoomType = reader.ReadUInt32();
            PairId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(Type);
            writer.Write(RoomType);
            writer.Write(PairId);
        }
    }
}
