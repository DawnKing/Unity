// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.SceneMessage
{
    // 通知更新投降表决信息
    public sealed class UpdateVotationInfo : IProtocol
    {
        public const short MsgType = MessageType.MSG_UPDATE_VOTATION_INFO;
        public short GetMsgType { get { return MsgType; } }
        public byte validCount;// 有效玩家数
        public byte[] vecVoteInfo;// 1:拒绝 2:同意
        
        public static void Send(byte validCount, byte[] vecVoteInfo, object className)
        {
            var packet = new UpdateVotationInfo
            {
                validCount = validCount,
                vecVoteInfo = vecVoteInfo
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
            validCount = reader.ReadByte();
            var length2 = reader.ReadUInt16();
            vecVoteInfo = new byte[length2];
            for (var i2 = 0; i2 < length2; i2++)
            {
                vecVoteInfo[i2] = reader.ReadByte();
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(validCount);
            ushort count2 = (ushort)(vecVoteInfo == null ? 0 : vecVoteInfo.Length);
            writer.Write(count2);
            for(var i2 = 0; i2 < count2; i2++)
            {
                writer.Write(vecVoteInfo[i2]);
            }
        }
    }
}
