// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TankMessage
{
    // 请求购买道具
    public sealed class SceneShopBuyMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_SCENE_SHOP_BUY;
        public short GetMsgType { get { return MsgType; } }
        public uint RoomId;// 房间id
        public uint PropsId;// 道具id
        public byte Type;// 使用的货币类型enum COIN_TYPE
        
        public static void Send(uint roomId, uint propsId, byte type, object className)
        {
            var packet = new SceneShopBuyMessage
            {
                RoomId = roomId,
                PropsId = propsId,
                Type = type
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
            RoomId = reader.ReadUInt32();
            PropsId = reader.ReadUInt32();
            Type = reader.ReadByte();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(RoomId);
            writer.Write(PropsId);
            writer.Write(Type);
        }
    }
}