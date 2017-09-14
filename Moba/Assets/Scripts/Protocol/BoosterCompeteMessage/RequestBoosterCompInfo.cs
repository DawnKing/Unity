// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.BoosterCompeteMessage
{
    /**
     * 请求角色助手竞技场信息
     * MSGTYPE_DECLARE(MSG_REQUEST_BOOSTER_COMP_INFO)
     */
    public sealed class RequestBoosterCompInfo : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_BOOSTER_COMP_INFO;
        public short GetMsgType { get { return MsgType; } }
        public uint NeedEnemyList;///是否需要发送挑战列表
        
        public static void Send(uint needEnemyList, object className)
        {
            var packet = new RequestBoosterCompInfo
            {
                NeedEnemyList = needEnemyList
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
            NeedEnemyList = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(NeedEnemyList);
        }
    }
}
