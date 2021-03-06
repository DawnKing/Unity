// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.MonitorMessage
{
    public sealed class NetProfileData
    {
        public ulong sendTotalBytes;// 发送总字节数
        public ulong recvTotalBytes;// 接收总字节数
        public uint sendTotalCnt;// 发送接口调用总次数
        public uint recvTotalCnt;// 接收接口调用总次数
        public uint outQueueSize;// 发送等待队列大小
        public uint inQueueSize;// 接收等待队列大小
        public uint handleMsgCnt;// 处理消息数
        public PacketProfileData[] packetProfileDataVec;// 网络包性能分析数据
        public void ReadFromStream(BinaryReader reader)
        {
            sendTotalBytes = reader.ReadUInt64();
            recvTotalBytes = reader.ReadUInt64();
            sendTotalCnt = reader.ReadUInt32();
            recvTotalCnt = reader.ReadUInt32();
            outQueueSize = reader.ReadUInt32();
            inQueueSize = reader.ReadUInt32();
            handleMsgCnt = reader.ReadUInt32();
            var length8 = reader.ReadUInt16();
            packetProfileDataVec = new PacketProfileData[length8];
            for (var i8 = 0; i8 < length8; i8++)
            {
                packetProfileDataVec[i8] = new PacketProfileData();
                packetProfileDataVec[i8].ReadFromStream(reader);
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(sendTotalBytes);
            writer.Write(recvTotalBytes);
            writer.Write(sendTotalCnt);
            writer.Write(recvTotalCnt);
            writer.Write(outQueueSize);
            writer.Write(inQueueSize);
            writer.Write(handleMsgCnt);
            ushort count8 = (ushort)(packetProfileDataVec == null ? 0 : packetProfileDataVec.Length);
            writer.Write(count8);
            for(var i8 = 0; i8 < count8; i8++)
            {
                packetProfileDataVec[i8].WriteToStream(writer);
            }
        }
    }
}
