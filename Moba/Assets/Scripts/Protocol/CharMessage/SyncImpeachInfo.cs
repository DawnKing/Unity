// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.CharMessage
{
    /// 同步举报结果 global <-> track
    public sealed class SyncImpeachInfo : IProtocol
    {
        public const short MsgType = MessageType.MSG_SYNC_IMPEACH_INFO;
        public short GetMsgType { get { return MsgType; } }
        public uint SceneId;
        public byte type;
        public byte roomType;
        public int Place;
        public uint SenderOid;
        public uint ReceiverOid;
        public uint ReceiverLvl;
        public string sReceiverName;
        public byte Result;//IMPEACH_RET_TYPE
        
        public static void Send(uint sceneId, byte type, byte roomType, int place, uint senderOid, uint receiverOid, uint receiverLvl, string sReceiverName, byte result, object className)
        {
            var packet = new SyncImpeachInfo
            {
                SceneId = sceneId,
                type = type,
                roomType = roomType,
                Place = place,
                SenderOid = senderOid,
                ReceiverOid = receiverOid,
                ReceiverLvl = receiverLvl,
                sReceiverName = sReceiverName,
                Result = result
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
            SceneId = reader.ReadUInt32();
            type = reader.ReadByte();
            roomType = reader.ReadByte();
            Place = reader.ReadInt32();
            SenderOid = reader.ReadUInt32();
            ReceiverOid = reader.ReadUInt32();
            ReceiverLvl = reader.ReadUInt32();
            sReceiverName = reader.ReadString();
            Result = reader.ReadByte();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(SceneId);
            writer.Write(type);
            writer.Write(roomType);
            writer.Write(Place);
            writer.Write(SenderOid);
            writer.Write(ReceiverOid);
            writer.Write(ReceiverLvl);
            writer.Write(sReceiverName);
            writer.Write(Result);
        }
    }
}
