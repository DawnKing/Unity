// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.NpcMessage
{
    // npc->Game 通知战场对话
    public sealed class NotifySceneTalk : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_SCENE_TALK;
        public short GetMsgType { get { return MsgType; } }
        public uint SceneId;// 战场ID
        public uint TalkId;// 对话ID(对话模板表)
        
        public static void Send(uint sceneId, uint talkId, object className)
        {
            var packet = new NotifySceneTalk
            {
                SceneId = sceneId,
                TalkId = talkId
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
            TalkId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(SceneId);
            writer.Write(TalkId);
        }
    }
}