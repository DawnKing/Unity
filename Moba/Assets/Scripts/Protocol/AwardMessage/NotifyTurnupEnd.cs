// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.AwardMessage
{
    /// 通知翻开其他牌
    public sealed class NotifyTurnupEnd : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_TURNUP_END;
        public short GetMsgType { get { return MsgType; } }
        public OneTurnupResult[] result;// 自动翻牌的结果
        public TurnupInfo[] infoVec;// 翻开所有的牌
        public uint State;// 翻牌状态 TURNUP_STATE
        
        public static void Send(OneTurnupResult[] result, TurnupInfo[] infoVec, uint state, object className)
        {
            var packet = new NotifyTurnupEnd
            {
                result = result,
                infoVec = infoVec,
                State = state
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
            result = new OneTurnupResult[length1];
            for (var i1 = 0; i1 < length1; i1++)
            {
                result[i1] = new OneTurnupResult();
                result[i1].ReadFromStream(reader);
            }
            var length2 = reader.ReadUInt16();
            infoVec = new TurnupInfo[length2];
            for (var i2 = 0; i2 < length2; i2++)
            {
                infoVec[i2] = new TurnupInfo();
                infoVec[i2].ReadFromStream(reader);
            }
            State = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            ushort count1 = (ushort)(result == null ? 0 : result.Length);
            writer.Write(count1);
            for(var i1 = 0; i1 < count1; i1++)
            {
                result[i1].WriteToStream(writer);
            }
            ushort count2 = (ushort)(infoVec == null ? 0 : infoVec.Length);
            writer.Write(count2);
            for(var i2 = 0; i2 < count2; i2++)
            {
                infoVec[i2].WriteToStream(writer);
            }
            writer.Write(State);
        }
    }
}