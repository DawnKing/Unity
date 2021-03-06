// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.CharMessage
{
    // MSGTYPE_DECLARE(MSG_NOTIFY_ADD_LEVEL),
    // 通知升级
    public sealed class NotifyAddLevel : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_ADD_LEVEL;
        public short GetMsgType { get { return MsgType; } }
        public uint Char;// 角色id
        public uint Level;// 升级后的等级
        public byte type;// enum LEVEL_TYPE
        
        public static void Send(uint char_, uint level, byte type, object className)
        {
            var packet = new NotifyAddLevel
            {
                Char = char_,
                Level = level,
                type = type
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
            Char = reader.ReadUInt32();
            Level = reader.ReadUInt32();
            type = reader.ReadByte();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(Char);
            writer.Write(Level);
            writer.Write(type);
        }
    }
}
