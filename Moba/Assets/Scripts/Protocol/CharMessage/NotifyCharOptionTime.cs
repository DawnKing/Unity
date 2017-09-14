// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.CharMessage
{
    // 更新角色vip时间戳
    public sealed class NotifyCharOptionTime : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_OPTION_TIME;
        public short GetMsgType { get { return MsgType; } }
        public uint Time;// 到期时间戳
        public uint AddTime;// 时间增加的秒数
        public byte type;// 功能类型 enum CHAR_OPTION_TYPE
        
        public static void Send(uint time, uint addTime, byte type, object className)
        {
            var packet = new NotifyCharOptionTime
            {
                Time = time,
                AddTime = addTime,
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
            Time = reader.ReadUInt32();
            AddTime = reader.ReadUInt32();
            type = reader.ReadByte();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(Time);
            writer.Write(AddTime);
            writer.Write(type);
        }
    }
}