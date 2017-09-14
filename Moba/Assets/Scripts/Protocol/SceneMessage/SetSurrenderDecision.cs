// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.SceneMessage
{
    // 设置玩家自己的投降信息
    public sealed class SetSurrenderDecision : IProtocol
    {
        public const short MsgType = MessageType.MSG_SET_SURRENDER_DECISION;
        public short GetMsgType { get { return MsgType; } }
        public byte result;// 1:拒绝 2:同意
        public uint SceneId;
        
        public static void Send(byte result, uint sceneId, object className)
        {
            var packet = new SetSurrenderDecision
            {
                result = result,
                SceneId = sceneId
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
            result = reader.ReadByte();
            SceneId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(result);
            writer.Write(SceneId);
        }
    }
}
