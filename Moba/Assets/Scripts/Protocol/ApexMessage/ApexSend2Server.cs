// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ApexMessage
{
    /**
    * 由 game client 发送给 gate server 的关于chcstart的返回值消息
    * 
    * MSGTYPE_DECLARE(MSG_APEX_SEND2CLIENT)
    */
    public sealed class ApexSend2Server : IProtocol
    {
        public const short MsgType = MessageType.MSG_APEX_SEND2SERVER;
        public short GetMsgType { get { return MsgType; } }// apex data here
        public char[] pBuffer;
        
        public static void Send(char[] pBuffer, object className)
        {
            var packet = new ApexSend2Server
            {
                pBuffer = pBuffer
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
            var length1 = reader.ReadUInt16();
            pBuffer = new char[length1];
            for (var i1 = 0; i1 < length1; i1++)
            {
                pBuffer[i1] = reader.ReadChar();
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            ushort count1 = (ushort)(pBuffer == null ? 0 : pBuffer.Length);
            writer.Write(count1);
            for(var i1 = 0; i1 < count1; i1++)
            {
                writer.Write(pBuffer[i1]);
            }
        }
    }
}
