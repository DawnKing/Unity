// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TeamMessage
{
    // global->guild
    public sealed class NotifyTeamMatchEnd : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_TEAM_MATCH_END;
        public short GetMsgType { get { return MsgType; } }
        public uint SceneId;// 战场ID
        public uint RoomType;// 房间类型 enum ROOM_TYPE
        public uint WinTeam;// 胜利的队伍
        public uint RedTeamId;
        public uint RedTrackSid;
        public uint RedRoomId;
        public string[] strRedUuid;// 红队玩家
        public string[] strBlueUuid;// 蓝队玩家
        
        public static void Send(uint sceneId, uint roomType, uint winTeam, uint redTeamId, uint redTrackSid, uint redRoomId, string[] strRedUuid, string[] strBlueUuid, object className)
        {
            var packet = new NotifyTeamMatchEnd
            {
                SceneId = sceneId,
                RoomType = roomType,
                WinTeam = winTeam,
                RedTeamId = redTeamId,
                RedTrackSid = redTrackSid,
                RedRoomId = redRoomId,
                strRedUuid = strRedUuid,
                strBlueUuid = strBlueUuid
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
            RoomType = reader.ReadUInt32();
            WinTeam = reader.ReadUInt32();
            RedTeamId = reader.ReadUInt32();
            RedTrackSid = reader.ReadUInt32();
            RedRoomId = reader.ReadUInt32();
            var length7 = reader.ReadUInt16();
            strRedUuid = new string[length7];
            for (var i7 = 0; i7 < length7; i7++)
            {
                strRedUuid[i7] = reader.ReadString();
            }
            var length8 = reader.ReadUInt16();
            strBlueUuid = new string[length8];
            for (var i8 = 0; i8 < length8; i8++)
            {
                strBlueUuid[i8] = reader.ReadString();
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(SceneId);
            writer.Write(RoomType);
            writer.Write(WinTeam);
            writer.Write(RedTeamId);
            writer.Write(RedTrackSid);
            writer.Write(RedRoomId);
            ushort count7 = (ushort)(strRedUuid == null ? 0 : strRedUuid.Length);
            writer.Write(count7);
            for(var i7 = 0; i7 < count7; i7++)
            {
                writer.Write(strRedUuid[i7]);
            }
            ushort count8 = (ushort)(strBlueUuid == null ? 0 : strBlueUuid.Length);
            writer.Write(count8);
            for(var i8 = 0; i8 < count8; i8++)
            {
                writer.Write(strBlueUuid[i8]);
            }
        }
    }
}
