// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.SceneMessage
{
    // Client通知track选坦克阶段选择坦克
    public sealed class RequestSelectUseTank : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_SELECT_USE_TANK;
        public short GetMsgType { get { return MsgType; } }
        public uint SceneId;//战场ID
        public uint TankId;//坦克ID
        public uint TankCont;// 坦克容器类型 enum TANK_CONTAINER_TYPE
        public byte roomType;
        
        public static void Send(uint sceneId, uint tankId, uint tankCont, byte roomType, object className)
        {
            var packet = new RequestSelectUseTank
            {
                SceneId = sceneId,
                TankId = tankId,
                TankCont = tankCont,
                roomType = roomType
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
            SceneId = reader.ReadUInt32();
            TankId = reader.ReadUInt32();
            TankCont = reader.ReadUInt32();
            roomType = reader.ReadByte();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(SceneId);
            writer.Write(TankId);
            writer.Write(TankCont);
            writer.Write(roomType);
        }
    }
}