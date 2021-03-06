// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.SystemMessage
{
    // ----------------------------------------------------------------------
    /// MSGTYPE_DECLARE_ASSIGN(MSG_LICENSE_NOTIFY, 7),
    // License Nitification from License Server
    public sealed class LicenseNotification : IProtocol
    {
        public const short MsgType = MessageType.MSG_LICENSE_NOTIFY;
        public short GetMsgType { get { return MsgType; } }
        public uint res;// 0 - 授权拒绝；1 - 授权通过
        public string newkey;// newkey used to generate next request
        
        public static void Send(uint res, string newkey, object className)
        {
            var packet = new LicenseNotification
            {
                res = res,
                newkey = newkey
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
            res = reader.ReadUInt32();
            newkey = reader.ReadString();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(res);
            writer.Write(newkey);
        }
    }
}
