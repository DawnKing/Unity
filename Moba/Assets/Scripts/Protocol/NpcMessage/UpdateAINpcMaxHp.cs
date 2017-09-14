// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.NpcMessage
{
    // game->client 通知客户端更新AINPC血上限
    public sealed class UpdateAINpcMaxHp : IProtocol
    {
        public const short MsgType = MessageType.MSG_UPDATE_AINPC_MAXHP;
        public short GetMsgType { get { return MsgType; } }
        public uint SceneId;// 战场ID
        public ulong ObjId;// 对象ID
        public uint MaxHp;// 血上限(当前血量和血上限相同)
        
        public static void Send(uint sceneId, ulong objId, uint maxHp, object className)
        {
            var packet = new UpdateAINpcMaxHp
            {
                SceneId = sceneId,
                ObjId = objId,
                MaxHp = maxHp
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
            MaxHp = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(SceneId);
            writer.Write(ObjId);
            writer.Write(MaxHp);
        }
    }
}
