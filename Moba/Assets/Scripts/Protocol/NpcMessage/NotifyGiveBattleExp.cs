// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.NpcMessage
{
    // npc->Game 通知给予战场经验
    public sealed class NotifyGiveBattleExp : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_GIVE_BATTLE_EXP;
        public short GetMsgType { get { return MsgType; } }
        public const int OT_PULL_CAR_SUC = 1;// 拉车成功
        public const int OT_PULL_COW_SUC = 2;// 拉牛成功
        public const int OT_AROUND_CAR_3_SEC = 3;// 在车子周围3s
        public uint SceneId;// 战场ID
        public ulong ObjId;// 对象ID
        public byte type;// 操作类型
        
        public static void Send(uint sceneId, ulong objId, byte type, object className)
        {
            var packet = new NotifyGiveBattleExp
            {
                SceneId = sceneId,
                ObjId = objId,
                type = type
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
            type = reader.ReadByte();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(SceneId);
            writer.Write(ObjId);
            writer.Write(type);
        }
    }
}
