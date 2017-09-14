// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.BoosterCompeteMessage
{
    /**
     * 通知助手挑战结束（Track -> Gate）
     * MSGTYPE_DECLARE(MSG_NOTIFY_BOOSTER_BATTLE_END)
     */
    public sealed class NotifyBoosterBattleEnd : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_BOOSTER_BATTLE_END;
        public short GetMsgType { get { return MsgType; } }
        public byte Win;/// 是否胜利(0 失败， 1 胜利)
        
        public static void Send(byte win, object className)
        {
            var packet = new NotifyBoosterBattleEnd
            {
                Win = win
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
            Win = reader.ReadByte();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(Win);
        }
    }
}
