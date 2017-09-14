// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.SceneMessage
{
    // game通知客户端播放投掷动画
    public sealed class NotifyObjThrow : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_OBJ_THROW;
        public short GetMsgType { get { return MsgType; } }
        public ulong Obj;// 对象 ID
        public short StartX;// 起点X坐标
        public short StartY;// 起点Y坐标
        public short DestX;// 目标点X坐标
        public short DestY;// 目标点Y坐标
        public uint Time;// 投掷时间
        
        public static void Send(ulong obj, short startX, short startY, short destX, short destY, uint time, object className)
        {
            var packet = new NotifyObjThrow
            {
                Obj = obj,
                StartX = startX,
                StartY = startY,
                DestX = destX,
                DestY = destY,
                Time = time
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
            Obj = reader.ReadUInt64();
            StartX = reader.ReadInt16();
            StartY = reader.ReadInt16();
            DestX = reader.ReadInt16();
            DestY = reader.ReadInt16();
            Time = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(Obj);
            writer.Write(StartX);
            writer.Write(StartY);
            writer.Write(DestX);
            writer.Write(DestY);
            writer.Write(Time);
        }
    }
}