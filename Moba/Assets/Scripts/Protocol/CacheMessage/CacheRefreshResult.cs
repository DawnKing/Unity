// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.CacheMessage
{
    // MSGTYPE_DECLARE(MSG_CACHING_REFRESH_RESULT),
    // 返回特定缓存刷新的结果
    public sealed class CacheRefreshResult : IProtocol
    {
        public const short MsgType = MessageType.MSG_CACHING_REFRESH_RESULT;
        public short GetMsgType { get { return MsgType; } }
        public string cacheKey;///- 缓存的KEY
        public uint result;///- 刷新的条数
        
        public static void Send(string cacheKey, uint result, object className)
        {
            var packet = new CacheRefreshResult
            {
                cacheKey = cacheKey,
                result = result
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
            cacheKey = reader.ReadString();
            result = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(cacheKey);
            writer.Write(result);
        }
    }
}
