// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.SystemMessage
{
    // MSGTYPE_DECLARE(MSG_OBSERVER_UNBIND_PLAYER_ACCOUNT),
    // 解除需要附身的玩家账号
    public sealed class ObserverUnBindPlayerAccountMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_OBSERVER_UNBIND_PLAYER_ACCOUNT;
        public short GetMsgType { get { return MsgType; } }
        public uint acctId;// 附身玩家账号id
        
        public static void Send(uint acctId, object className)
        {
            var packet = new ObserverUnBindPlayerAccountMessage
            {
                acctId = acctId
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
            acctId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(acctId);
        }
    }
}