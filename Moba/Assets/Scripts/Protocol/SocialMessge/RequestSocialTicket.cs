// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.SocialMessge
{
    // ----------------------------------------------------------------------
    ///    @file            protocol/SocialMessage.h
    ///    @brief
    ///    @author          libo
    ///    @copyright       Sixcube Information Technology Co,. Ltd. (2012)
    ///    @date
    // ----------------------------------------------------------------------
    // 请求领取一个临时师徒关系的邀请码
    public sealed class RequestSocialTicket : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_SOCIAL_TICKET;
        public short GetMsgType { get { return MsgType; } }
        public uint socialType;// 关系的类型, 参见CHAR_SOCIAL_TYPE
        
        public static void Send(uint socialType, object className)
        {
            var packet = new RequestSocialTicket
            {
                socialType = socialType
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
            socialType = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(socialType);
        }
    }
}