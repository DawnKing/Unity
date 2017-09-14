// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

using GameProtocol.BulkDataType;
namespace GameProtocol.NpcMessage
{
    // MSGTYPE_DECLARE(MSG_NPC_SYNC_ATTRS),
    // gamesvr->npc 通知同步属性数据
    public sealed class NpcSyncAttrs : IProtocol
    {
        public const short MsgType = MessageType.MSG_NPC_SYNC_ATTRS;
        public short GetMsgType { get { return MsgType; } }
        public uint SceneId;// 场景id
        public ulong TankId;// 坦克id
        public OBJECT_ATTR attr;// 玩家的属性
        
        public static void Send(uint sceneId, ulong tankId, OBJECT_ATTR attr, object className)
        {
            var packet = new NpcSyncAttrs
            {
                SceneId = sceneId,
                TankId = tankId,
                attr = attr
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
            TankId = reader.ReadUInt64();
            attr = new OBJECT_ATTR();
            attr.ReadFromStream(reader);
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(SceneId);
            writer.Write(TankId);
            attr.WriteToStream(writer);
        }
    }
}