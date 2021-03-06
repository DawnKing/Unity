// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.NpcMessage
{
    // npc->Game 通知 GAME 删除BUFF
    public sealed class NpcRemoveBuff : IProtocol
    {
        public const short MsgType = MessageType.MSG_NPC_REMOVE_BUFF;
        public short GetMsgType { get { return MsgType; } }
        public uint SceneID;// 战场ID
        public uint ObjType;// 对象类型
        public ulong ObjId;// 对象ID
        public uint BuffId;// BUFF id
        
        public static void Send(uint sceneID, uint objType, ulong objId, uint buffId, object className)
        {
            var packet = new NpcRemoveBuff
            {
                SceneID = sceneID,
                ObjType = objType,
                ObjId = objId,
                BuffId = buffId
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
            SceneID = reader.ReadUInt32();
            ObjType = reader.ReadUInt32();
            ObjId = reader.ReadUInt64();
            BuffId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(SceneID);
            writer.Write(ObjType);
            writer.Write(ObjId);
            writer.Write(BuffId);
        }
    }
}
