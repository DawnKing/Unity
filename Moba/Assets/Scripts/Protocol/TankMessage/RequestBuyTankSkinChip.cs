// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TankMessage
{
    public sealed class RequestBuyTankSkinChip : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_BUY_TANK_SKIN_CHIP;
        public short GetMsgType { get { return MsgType; } }
        public byte Batch;///是否10连
        public uint SkinId;///皮肤ID
        public uint CoinType;///货币类型
        
        public static void Send(byte batch, uint skinId, uint coinType, object className)
        {
            var packet = new RequestBuyTankSkinChip
            {
                Batch = batch,
                SkinId = skinId,
                CoinType = coinType
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
            Batch = reader.ReadByte();
            SkinId = reader.ReadUInt32();
            CoinType = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(Batch);
            writer.Write(SkinId);
            writer.Write(CoinType);
        }
    }
}
