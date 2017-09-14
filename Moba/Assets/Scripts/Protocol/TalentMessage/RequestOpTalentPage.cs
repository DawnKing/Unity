// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TalentMessage
{
    // 请求天赋页操作
    public sealed class RequestOpTalentPage : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_OP_TALENT_PAGE;
        public short GetMsgType { get { return MsgType; } }
        public uint opType;// 天赋操作类型
        public string strPageUuid;// 天赋页uuid
        public string tankUuid;// 坦克uuid
        
        public static void Send(uint opType, string strPageUuid, string tankUuid, object className)
        {
            var packet = new RequestOpTalentPage
            {
                opType = opType,
                strPageUuid = strPageUuid,
                tankUuid = tankUuid
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
            opType = reader.ReadUInt32();
            strPageUuid = reader.ReadString();
            tankUuid = reader.ReadString();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(opType);
            writer.Write(strPageUuid);
            writer.Write(tankUuid);
        }
    }
}
