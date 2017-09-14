// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.StoreMessage
{
    // ----------------------------------------------------------------------
    ///    @file            protocol/StoreMessage.h
    ///    @brief
    ///    @author          libo
    ///    @copyright       Sixcube Information Technology Co,. Ltd. (2012)
    ///    @date
    // ----------------------------------------------------------------------
    // 请求打开商店(会检查刷新)
    public sealed class RequestStoreMerchandise : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_STORE_MERCHANDISE;
        public short GetMsgType { get { return MsgType; } }
        public uint storeType;// 商店类型, 参见STORE_TYPE
        
        public static void Send(uint storeType, object className)
        {
            var packet = new RequestStoreMerchandise
            {
                storeType = storeType
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
            storeType = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(storeType);
        }
    }
}
