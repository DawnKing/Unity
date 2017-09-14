// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

using GameProtocol.ShareTypes;
namespace GameProtocol.MovementMessage
{
    // MSGTYPE_DECLARE(MSG_NOTIFY_SEEK_PATH)
    // 通知预缓存的寻径结果
    public sealed class NotifyRobotCachePath : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_ROBOT_CACHE_PATH;
        public short GetMsgType { get { return MsgType; } }
        public uint MapId;// 地图ID
        public MapPos[] pathVec;// 路径信息
        
        public static void Send(uint mapId, MapPos[] pathVec, object className)
        {
            var packet = new NotifyRobotCachePath
            {
                MapId = mapId,
                pathVec = pathVec
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
            var length2 = reader.ReadUInt16();
            pathVec = new MapPos[length2];
            for (var i2 = 0; i2 < length2; i2++)
            {
                pathVec[i2] = new MapPos();
                pathVec[i2].ReadFromStream(reader);
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(MapId);
            ushort count2 = (ushort)(pathVec == null ? 0 : pathVec.Length);
            writer.Write(count2);
            for(var i2 = 0; i2 < count2; i2++)
            {
                pathVec[i2].WriteToStream(writer);
            }
        }
    }
}