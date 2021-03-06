// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.AuthMessage
{
    /*
     * MSG_SERVER_LOGOUT_CONFIRMED
     */
    public sealed class ServerLogoutConfirm : IProtocol
    {
        public const short MsgType = MessageType.MSG_SERVER_LOGOUT_CONFIRMED;
        public short GetMsgType { get { return MsgType; } }
        public uint session;// session key
        
        public static void Send(uint session, object className)
        {
            var packet = new ServerLogoutConfirm
            {
                session = session
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
            session = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(session);
        }
    }
}
