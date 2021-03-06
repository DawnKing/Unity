// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

using GameProtocol.BulkDataType;
namespace GameProtocol.RoomMessage
{
    // 正常进入
    // 中途加入
    // 观战
    // MSGTYPE_DECLARE(MSG_GATE_ENTER_SCENE),
    // 通知gate坦克进入战场
    public sealed class GateEnterScene : IProtocol
    {
        public const short MsgType = MessageType.MSG_GATE_ENTER_SCENE;
        public short GetMsgType { get { return MsgType; } }
        public uint GameSvrId;// 游戏服务器id
        public byte roomType;// enum ROOM_TYPE
        public uint MapId;// 地图id
        public uint SceneId;// 战场id
        public byte campId;// 阵营
        public byte EnterType;// enum ENTER_SCENE_TYPE
        public BATTLE_INFO info;// tracksvr提供的信息
        
        public static void Send(uint gameSvrId, byte roomType, uint mapId, uint sceneId, byte campId, byte enterType, BATTLE_INFO info, object className)
        {
            var packet = new GateEnterScene
            {
                GameSvrId = gameSvrId,
                roomType = roomType,
                MapId = mapId,
                SceneId = sceneId,
                campId = campId,
                EnterType = enterType,
                info = info
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
            GameSvrId = reader.ReadUInt32();
            roomType = reader.ReadByte();
            MapId = reader.ReadUInt32();
            SceneId = reader.ReadUInt32();
            campId = reader.ReadByte();
            EnterType = reader.ReadByte();
            info = new BATTLE_INFO();
            info.ReadFromStream(reader);
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(GameSvrId);
            writer.Write(roomType);
            writer.Write(MapId);
            writer.Write(SceneId);
            writer.Write(campId);
            writer.Write(EnterType);
            info.WriteToStream(writer);
        }
    }
}
