// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.RoomMessage
{
    // MSGTYPE_DECLARE(MSG_CLEAR_KICKOUT_COUNTDOWN),
    // 通知清除房间踢人倒计时
    public sealed class ClearKickoutCountdown : IProtocol
    {
        public const short MsgType = MessageType.MSG_CLEAR_KICKOUT_COUNTDOWN;
        public short GetMsgType { get { return MsgType; } }
        public uint charId;// 目标玩家
        
        public static void Send(uint charId, object className)
        {
            var packet = new ClearKickoutCountdown
            {
                charId = charId
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
            charId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(charId);
        }
    }
}