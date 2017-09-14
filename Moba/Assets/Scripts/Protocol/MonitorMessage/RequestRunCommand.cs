// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.MonitorMessage
{
    /// 请求远程服务器运行命令
    /// MSG_RUN_ROMOTE_COMMAND
    public sealed class RequestRunCommand : IProtocol
    {
        public const short MsgType = MessageType.MSG_RUN_ROMOTE_COMMAND;
        public short GetMsgType { get { return MsgType; } }
        public int requestId;
        public string command;
        
        public static void Send(int requestId, string command, object className)
        {
            var packet = new RequestRunCommand
            {
                requestId = requestId,
                command = command
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
            requestId = reader.ReadInt32();
            command = reader.ReadString();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(requestId);
            writer.Write(command);
        }
    }
}
