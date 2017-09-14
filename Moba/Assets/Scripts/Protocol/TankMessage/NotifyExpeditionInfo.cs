// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TankMessage
{
    // 通知远征信息
    public sealed class NotifyExpeditionInfo : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_EXPEDITION_INFO;
        public short GetMsgType { get { return MsgType; } }
        public uint m_nTime1;
        public uint m_nTime2;
        public uint m_nTime3;
        public uint m_nTankId1;
        public uint m_nTankId2;
        public uint m_nTankId3;
        public uint m_nTankId4;
        public uint m_nTankId5;
        public uint m_nTankId6;
        public uint m_nTankId7;
        public uint m_nTankId8;
        public uint m_nTankId9;
        
        public static void Send(uint m_nTime1, uint m_nTime2, uint m_nTime3, uint m_nTankId1, uint m_nTankId2, uint m_nTankId3, uint m_nTankId4, uint m_nTankId5, uint m_nTankId6, uint m_nTankId7, uint m_nTankId8, uint m_nTankId9, object className)
        {
            var packet = new NotifyExpeditionInfo
            {
                m_nTime1 = m_nTime1,
                m_nTime2 = m_nTime2,
                m_nTime3 = m_nTime3,
                m_nTankId1 = m_nTankId1,
                m_nTankId2 = m_nTankId2,
                m_nTankId3 = m_nTankId3,
                m_nTankId4 = m_nTankId4,
                m_nTankId5 = m_nTankId5,
                m_nTankId6 = m_nTankId6,
                m_nTankId7 = m_nTankId7,
                m_nTankId8 = m_nTankId8,
                m_nTankId9 = m_nTankId9
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
            m_nTime1 = reader.ReadUInt32();
            m_nTime2 = reader.ReadUInt32();
            m_nTime3 = reader.ReadUInt32();
            m_nTankId1 = reader.ReadUInt32();
            m_nTankId2 = reader.ReadUInt32();
            m_nTankId3 = reader.ReadUInt32();
            m_nTankId4 = reader.ReadUInt32();
            m_nTankId5 = reader.ReadUInt32();
            m_nTankId6 = reader.ReadUInt32();
            m_nTankId7 = reader.ReadUInt32();
            m_nTankId8 = reader.ReadUInt32();
            m_nTankId9 = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(m_nTime1);
            writer.Write(m_nTime2);
            writer.Write(m_nTime3);
            writer.Write(m_nTankId1);
            writer.Write(m_nTankId2);
            writer.Write(m_nTankId3);
            writer.Write(m_nTankId4);
            writer.Write(m_nTankId5);
            writer.Write(m_nTankId6);
            writer.Write(m_nTankId7);
            writer.Write(m_nTankId8);
            writer.Write(m_nTankId9);
        }
    }
}
