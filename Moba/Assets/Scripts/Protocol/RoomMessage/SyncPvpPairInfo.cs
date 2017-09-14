// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

using GameProtocol.BulkDataType;
namespace GameProtocol.RoomMessage
{
    // MSGTYPE_DECLARE(MSG_SYNC_PVP_PAIR_INFO),
    // 通知匹配信息
    public sealed class SyncPvpPairInfo : IProtocol
    {
        public const short MsgType = MessageType.MSG_SYNC_PVP_PAIR_INFO;
        public short GetMsgType { get { return MsgType; } }
        public PvpPairInfo[] infoVec;// 匹配信息列表
        
        public static void Send(PvpPairInfo[] infoVec, object className)
        {
            var packet = new SyncPvpPairInfo
            {
                infoVec = infoVec
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
            infoVec = new PvpPairInfo[length1];
            for (var i1 = 0; i1 < length1; i1++)
            {
                infoVec[i1] = new PvpPairInfo();
                infoVec[i1].ReadFromStream(reader);
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            ushort count1 = (ushort)(infoVec == null ? 0 : infoVec.Length);
            writer.Write(count1);
            for(var i1 = 0; i1 < count1; i1++)
            {
                infoVec[i1].WriteToStream(writer);
            }
        }
    }
}
