// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.AuthMessage
{
    /**
     * 网关游戏服务器不可用
     */
    public sealed class PlayFail : IProtocol
    {
        public const short MsgType = MessageType.MSG_AUTH_PLAY_FAIL;
        public short GetMsgType { get { return MsgType; } }
        public int reason;
        
        public static void Send(int reason, object className)
        {
            var packet = new PlayFail
            {
                reason = reason
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
            reason = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(reason);
        }
    }
}