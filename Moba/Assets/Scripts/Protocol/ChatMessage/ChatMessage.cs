// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

using GameProtocol.ShareTypes;
namespace GameProtocol.ChatMessage
{
    /**
     * 聊天消息 
     * MSGTYPE_DECLARE(MSG_CHAT_MESSAGE)
     */
    public sealed class ChatMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_CHAT_MESSAGE;
        public short GetMsgType { get { return MsgType; } }
        public ChatContents contents;
        public long recvClientTime;
        public long recvChatTime;
        
        public static void Send(ChatContents contents, long recvClientTime, long recvChatTime, object className)
        {
            var packet = new ChatMessage
            {
                contents = contents,
                recvClientTime = recvClientTime,
                recvChatTime = recvChatTime
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
            contents = new ChatContents();
            contents.ReadFromStream(reader);
            recvClientTime = reader.ReadInt64();
            recvChatTime = reader.ReadInt64();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            contents.WriteToStream(writer);
            writer.Write(recvClientTime);
            writer.Write(recvChatTime);
        }
    }
}
