// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.RoomMessage
{
    // MSGTYPE_DECLARE(MSG_GLOBAL_DEL_SCENE_LIST),
    // 通知删除战场列表信息
    public sealed class GlobalDelSceneList : IProtocol
    {
        public const short MsgType = MessageType.MSG_GLOBAL_DEL_SCENE_LIST;
        public short GetMsgType { get { return MsgType; } }
        public byte Type;// 战场类型
        public uint sceneId;// 要删除的战场id
        
        public static void Send(byte type, uint sceneId, object className)
        {
            var packet = new GlobalDelSceneList
            {
                Type = type,
                sceneId = sceneId
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
            sceneId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(Type);
            writer.Write(sceneId);
        }
    }
}
