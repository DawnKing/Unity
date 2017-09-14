// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ItemMessage
{
    /// 通知轮盘赌结果
    public sealed class NotifyRouletteRet : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_ROULETTE_RET;
        public short GetMsgType { get { return MsgType; } }
        public uint OutId;// 外圈id
        public uint InId;// 内圈id
        
        public static void Send(uint outId, uint inId, object className)
        {
            var packet = new NotifyRouletteRet
            {
                OutId = outId,
                InId = inId
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
            OutId = reader.ReadUInt32();
            InId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(OutId);
            writer.Write(InId);
        }
    }
}