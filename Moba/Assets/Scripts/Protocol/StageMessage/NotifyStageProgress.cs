// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.StageMessage
{
    //MSGTYPE_DECLARE(MSG_NOTIFY_STAGE_PROGRESS),
    // 通知奖励领取的进度
    public sealed class NotifyStageProgress : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_STAGE_PROGRESS;
        public short GetMsgType { get { return MsgType; } }
        public uint stage;// 参见CHAR_STAGE枚举
        public uint[] now;// 当前值
        public uint[] max;// 最大值
        
        public static void Send(uint stage, uint[] now, uint[] max, object className)
        {
            var packet = new NotifyStageProgress
            {
                stage = stage,
                now = now,
                max = max
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
            stage = reader.ReadUInt32();
            var length2 = reader.ReadUInt16();
            now = new uint[length2];
            for (var i2 = 0; i2 < length2; i2++)
            {
                now[i2] = reader.ReadUInt32();
            }
            var length3 = reader.ReadUInt16();
            max = new uint[length3];
            for (var i3 = 0; i3 < length3; i3++)
            {
                max[i3] = reader.ReadUInt32();
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(stage);
            ushort count2 = (ushort)(now == null ? 0 : now.Length);
            writer.Write(count2);
            for(var i2 = 0; i2 < count2; i2++)
            {
                writer.Write(now[i2]);
            }
            ushort count3 = (ushort)(max == null ? 0 : max.Length);
            writer.Write(count3);
            for(var i3 = 0; i3 < count3; i3++)
            {
                writer.Write(max[i3]);
            }
        }
    }
}
