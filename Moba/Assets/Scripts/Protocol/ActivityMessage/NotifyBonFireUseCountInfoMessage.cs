// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ActivityMessage
{
    /// 通知篝火活动添加柴火信息
    public sealed class NotifyBonFireUseCountInfoMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_BONFIRE_USE_COUNT_INFO;
        public short GetMsgType { get { return MsgType; } }
        public uint prevTotalUseCnt;//  上次总使用数
        public uint curAddUseCnt;//  本次增加次数
        public int useParam;//  添加柴火参数
        
        public static void Send(uint prevTotalUseCnt, uint curAddUseCnt, int useParam, object className)
        {
            var packet = new NotifyBonFireUseCountInfoMessage
            {
                prevTotalUseCnt = prevTotalUseCnt,
                curAddUseCnt = curAddUseCnt,
                useParam = useParam
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
            prevTotalUseCnt = reader.ReadUInt32();
            curAddUseCnt = reader.ReadUInt32();
            useParam = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(prevTotalUseCnt);
            writer.Write(curAddUseCnt);
            writer.Write(useParam);
        }
    }
}
