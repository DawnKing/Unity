// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.SceneMessage
{
    // MSGTYPE_DECLARE(MSG_REQUEST_EXIT_BATTLE),
    // 客户端请求退出战场
    public sealed class RequestExitBattle : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_EXIT_BATTLE;
        public short GetMsgType { get { return MsgType; } }
        public uint SceneId;// 房间id
        
        public static void Send(uint sceneId, object className)
        {
            var packet = new RequestExitBattle
            {
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
            SceneId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(SceneId);
        }
    }
}