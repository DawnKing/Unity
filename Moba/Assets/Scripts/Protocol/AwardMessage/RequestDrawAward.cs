// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.AwardMessage
{
    //////////////////////////////////////////////////////////////////////////
    // 运营奖励相关
    // 奖励领取类型
    // 不需要任何验证
    // 不需要验证码，需要验证帐号
    // 需要验证码
    // 不需要验证码，需要验证角色uuid
    // MSGTYPE_DECLARE(MSG_REQUEST_DRAW_AWARD),
    // 请求领取奖励
    public sealed class RequestDrawAward : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_DRAW_AWARD;
        public short GetMsgType { get { return MsgType; } }
        public uint awardId;// 奖励id
        public string validate;// 奖励验证码
        
        public static void Send(uint awardId, string validate, object className)
        {
            var packet = new RequestDrawAward
            {
                awardId = awardId,
                validate = validate
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
            awardId = reader.ReadUInt32();
            validate = reader.ReadString();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(awardId);
            writer.Write(validate);
        }
    }
}
