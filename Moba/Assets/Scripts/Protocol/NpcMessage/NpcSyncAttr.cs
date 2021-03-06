// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.NpcMessage
{
    // MSGTYPE_DECLARE(MSG_NPC_SYNC_ATTR)
    // gamesvr->npc 同步对象属性
    public sealed class NpcSyncAttr : IProtocol
    {
        public const short MsgType = MessageType.MSG_NPC_SYNC_ATTR;
        public short GetMsgType { get { return MsgType; } }
        public uint SceneId;// 战场id
        public ulong ObjId;// 对象id
        public uint AttrType;// 属性类型
        public int Value;// 属性值
        public ulong casterId;// 释放者ID
        
        public static void Send(uint sceneId, ulong objId, uint attrType, int value, ulong casterId, object className)
        {
            var packet = new NpcSyncAttr
            {
                SceneId = sceneId,
                ObjId = objId,
                AttrType = attrType,
                Value = value,
                casterId = casterId
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
            ObjId = reader.ReadUInt64();
            AttrType = reader.ReadUInt32();
            Value = reader.ReadInt32();
            casterId = reader.ReadUInt64();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(SceneId);
            writer.Write(ObjId);
            writer.Write(AttrType);
            writer.Write(Value);
            writer.Write(casterId);
        }
    }
}
