// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

using GameProtocol.BulkDataType;
namespace GameProtocol.NpcMessage
{
    // MSGTYPE_DECLARE(MSG_NPC_SCENE_INIT),
    // npc->gamesvr 通知场景npc初始化
    public sealed class NpcSceneInit : IProtocol
    {
        public const short MsgType = MessageType.MSG_NPC_SCENE_INIT;
        public short GetMsgType { get { return MsgType; } }
        public uint SceneId;// 战场id
        public ObjInfo[] objVec;// 场景对象数据
        
        public static void Send(uint sceneId, ObjInfo[] objVec, object className)
        {
            var packet = new NpcSceneInit
            {
                SceneId = sceneId,
                objVec = objVec
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
            var length2 = reader.ReadUInt16();
            objVec = new ObjInfo[length2];
            for (var i2 = 0; i2 < length2; i2++)
            {
                objVec[i2] = new ObjInfo();
                objVec[i2].ReadFromStream(reader);
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(SceneId);
            ushort count2 = (ushort)(objVec == null ? 0 : objVec.Length);
            writer.Write(count2);
            for(var i2 = 0; i2 < count2; i2++)
            {
                objVec[i2].WriteToStream(writer);
            }
        }
    }
}
