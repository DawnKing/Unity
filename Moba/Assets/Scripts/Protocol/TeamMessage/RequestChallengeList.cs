// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TeamMessage
{
    // 请求约战列表
    public sealed class RequestChallengeList : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_CHALLENGE_LIST;
        public short GetMsgType { get { return MsgType; } }
        public uint Activity;// 活动类型 参见ACTIVITY_TYPE枚举
        public uint Contest;// 联赛对阵
        
        public static void Send(uint activity, uint contest, object className)
        {
            var packet = new RequestChallengeList
            {
                Activity = activity,
                Contest = contest
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
            Activity = reader.ReadUInt32();
            Contest = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(Activity);
            writer.Write(Contest);
        }
    }
}
