// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TankMessage
{
    // 请求将皮肤进度兑换成皮肤
    public sealed class RequestGetTankSkin : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_GET_TANK_SKIN;
        public short GetMsgType { get { return MsgType; } }
        public uint SkinId;/// 皮肤ID
        
        public static void Send(uint skinId, object className)
        {
            var packet = new RequestGetTankSkin
            {
                SkinId = skinId
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
            SkinId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(SkinId);
        }
    }
}
