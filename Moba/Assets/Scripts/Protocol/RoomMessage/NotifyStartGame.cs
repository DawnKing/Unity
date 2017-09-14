// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

using GameProtocol.BulkDataType;
namespace GameProtocol.RoomMessage
{
    // MSGTYPE_DECLARE_ASSIGN(MSG_NOTIFY_START_GAME, 1500),
    // 成功进入房间，开始游戏
    public sealed class NotifyStartGame : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_START_GAME;
        public short GetMsgType { get { return MsgType; } }
        public uint SceneId;
        public uint MapId;// 地图模板id
        public byte type;// ROOM_TYPE
        public CHAR_BRIEF[] charData;// 成员数据（所有的成员，包括下线者）
        public uint[] backData;// 下线者的ID
        public byte EnterType;// enum ENTER_SCENE_TYPE
        
        public static void Send(uint sceneId, uint mapId, byte type, CHAR_BRIEF[] charData, uint[] backData, byte enterType, object className)
        {
            var packet = new NotifyStartGame
            {
                SceneId = sceneId,
                MapId = mapId,
                type = type,
                charData = charData,
                backData = backData,
                EnterType = enterType
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
            SceneId = reader.ReadUInt32();
            MapId = reader.ReadUInt32();
            type = reader.ReadByte();
            var length4 = reader.ReadUInt16();
            charData = new CHAR_BRIEF[length4];
            for (var i4 = 0; i4 < length4; i4++)
            {
                charData[i4] = new CHAR_BRIEF();
                charData[i4].ReadFromStream(reader);
            }
            var length5 = reader.ReadUInt16();
            backData = new uint[length5];
            for (var i5 = 0; i5 < length5; i5++)
            {
                backData[i5] = reader.ReadUInt32();
            }
            EnterType = reader.ReadByte();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(SceneId);
            writer.Write(MapId);
            writer.Write(type);
            ushort count4 = (ushort)(charData == null ? 0 : charData.Length);
            writer.Write(count4);
            for(var i4 = 0; i4 < count4; i4++)
            {
                charData[i4].WriteToStream(writer);
            }
            ushort count5 = (ushort)(backData == null ? 0 : backData.Length);
            writer.Write(count5);
            for(var i5 = 0; i5 < count5; i5++)
            {
                writer.Write(backData[i5]);
            }
            writer.Write(EnterType);
        }
    }
}