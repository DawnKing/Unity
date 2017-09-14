// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ApexMessage
{
    /**
    * 
    * MSGTYPE_DECLARE(MSG_APEX_SENDRETVAL2CLIENT)
    */
    public sealed class ApexSendRetVal2Server : IProtocol
    {
        public const short MsgType = MessageType.MSG_APEX_SENDRETVAL2SERVER;
        public short GetMsgType { get { return MsgType; } }
        public int RetVal;
        
        public static void Send(int retVal, object className)
        {
            var packet = new ApexSendRetVal2Server
            {
                RetVal = retVal
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
            RetVal = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(RetVal);
        }
    }
}
