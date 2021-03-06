// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.CharMessage
{
    // 通知荣誉列表
    public sealed class NotifyHonorList : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_HONOR_LIST;
        public short GetMsgType { get { return MsgType; } }
        public uint[] honorList;// 荣誉id列表
        public uint OpType;// INFO_OP_TYPE
        
        public static void Send(uint[] honorList, uint opType, object className)
        {
            var packet = new NotifyHonorList
            {
                honorList = honorList,
                OpType = opType
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
            var length1 = reader.ReadUInt16();
            honorList = new uint[length1];
            for (var i1 = 0; i1 < length1; i1++)
            {
                honorList[i1] = reader.ReadUInt32();
            }
            OpType = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            ushort count1 = (ushort)(honorList == null ? 0 : honorList.Length);
            writer.Write(count1);
            for(var i1 = 0; i1 < count1; i1++)
            {
                writer.Write(honorList[i1]);
            }
            writer.Write(OpType);
        }
    }
}
