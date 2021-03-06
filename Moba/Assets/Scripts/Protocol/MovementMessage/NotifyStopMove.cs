// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.MovementMessage
{
    /**
     * 停止移动通知消息 
     */
    public sealed class NotifyStopMove : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_STOP_MOVE;
        public short GetMsgType { get { return MsgType; } }
        public uint sceneId;// 战场id
        public ulong oid;// 对象id
        public ushort x;// 停止点
        public ushort y;// 停止点
        
        public static void Send(uint sceneId, ulong oid, ushort x, ushort y, object className)
        {
            var packet = new NotifyStopMove
            {
                sceneId = sceneId,
                oid = oid,
                x = x,
                y = y
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
            sceneId = reader.ReadUInt32();
            oid = reader.ReadUInt64();
            x = reader.ReadUInt16();
            y = reader.ReadUInt16();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(sceneId);
            writer.Write(oid);
            writer.Write(x);
            writer.Write(y);
        }
    }
}
