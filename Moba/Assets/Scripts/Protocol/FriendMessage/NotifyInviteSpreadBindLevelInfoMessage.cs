// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.FriendMessage
{
    /// 通知邀请推广绑定等级人数
    public sealed class NotifyInviteSpreadBindLevelInfoMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_INVITE_SPREAD_BIND_LEVEL_INFO;
        public short GetMsgType { get { return MsgType; } }
        public uint m_level10Cnt;// 大于等于十级人数
        public uint m_level15Cnt;// 大于等于十五级人数
        public uint m_level0Cnt;// 大于等于0级人数
        
        public static void Send(uint m_level10Cnt, uint m_level15Cnt, uint m_level0Cnt, object className)
        {
            var packet = new NotifyInviteSpreadBindLevelInfoMessage
            {
                m_level10Cnt = m_level10Cnt,
                m_level15Cnt = m_level15Cnt,
                m_level0Cnt = m_level0Cnt
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
            m_level10Cnt = reader.ReadUInt32();
            m_level15Cnt = reader.ReadUInt32();
            m_level0Cnt = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(m_level10Cnt);
            writer.Write(m_level15Cnt);
            writer.Write(m_level0Cnt);
        }
    }
}
