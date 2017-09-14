// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.RoomMessage
{
    // MSGTYPE_DECLARE(MSG_NOTIFY_ROOM_MAP),
    // 通知地图
    public sealed class NotifyRoomMap : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_ROOM_MAP;
        public short GetMsgType { get { return MsgType; } }
        public uint MapId;// 地图id
        
        public static void Send(uint mapId, object className)
        {
            var packet = new NotifyRoomMap
            {
                MapId = mapId
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
            MapId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(MapId);
        }
    }
}
