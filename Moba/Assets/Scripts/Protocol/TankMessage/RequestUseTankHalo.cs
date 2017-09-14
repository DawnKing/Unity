// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TankMessage
{
    // 请求使用坦克光环 client -> gate
    public sealed class RequestUseTankHalo : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_USE_TANK_HALO;
        public short GetMsgType { get { return MsgType; } }
        public string sTankUUID;//坦克uuid
        public uint HaloId;//光环的物品id
        
        public static void Send(string sTankUUID, uint haloId, object className)
        {
            var packet = new RequestUseTankHalo
            {
                sTankUUID = sTankUUID,
                HaloId = haloId
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
            sTankUUID = reader.ReadString();
            HaloId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(sTankUUID);
            writer.Write(HaloId);
        }
    }
}