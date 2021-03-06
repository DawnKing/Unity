// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.GlobalMessage
{
    // MSGTYPE_DECLARE(MSG_GLOBAL_REQUEST_SET_MAP),
    // 请求设置地图
    public sealed class GlobalRequestSetMap : IProtocol
    {
        public const short MsgType = MessageType.MSG_GLOBAL_REQUEST_SET_MAP;
        public short GetMsgType { get { return MsgType; } }
        public uint CharOid;// 角色OID
        public uint RoomId;// 房间id
        public uint MapId;// 地图id
        
        public static void Send(uint charOid, uint roomId, uint mapId, object className)
        {
            var packet = new GlobalRequestSetMap
            {
                CharOid = charOid,
                RoomId = roomId,
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
            CharOid = reader.ReadUInt32();
            RoomId = reader.ReadUInt32();
            MapId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(CharOid);
            writer.Write(RoomId);
            writer.Write(MapId);
        }
    }
}
