// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ActivityMessage
{
    /// 通知自己的点赞信息
    public sealed class NotifyRandStepSupportInfoMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_RAND_STEP_SUPPORT_INFO;
        public short GetMsgType { get { return MsgType; } }
        public string[] supportUuidVec;
        
        public static void Send(string[] supportUuidVec, object className)
        {
            var packet = new NotifyRandStepSupportInfoMessage
            {
                supportUuidVec = supportUuidVec
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
            supportUuidVec = new string[length1];
            for (var i1 = 0; i1 < length1; i1++)
            {
                supportUuidVec[i1] = reader.ReadString();
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            ushort count1 = (ushort)(supportUuidVec == null ? 0 : supportUuidVec.Length);
            writer.Write(count1);
            for(var i1 = 0; i1 < count1; i1++)
            {
                writer.Write(supportUuidVec[i1]);
            }
        }
    }
}
