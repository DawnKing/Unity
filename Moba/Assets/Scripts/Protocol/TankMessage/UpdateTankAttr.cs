// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TankMessage
{
    // MSGTYPE_DECLARE(MSG_UPDATE_TANK_ATTR),
    // 通知更新坦克数据
    public sealed class UpdateTankAttr : IProtocol
    {
        public const short MsgType = MessageType.MSG_UPDATE_TANK_ATTR;
        public short GetMsgType { get { return MsgType; } }
        public uint tankId;// 坦克id
        public byte updateType;// 更新类型 enum TANK_ATTR_TYPE
        public int UpdateVal;// 更新值
        
        public static void Send(uint tankId, byte updateType, int updateVal, object className)
        {
            var packet = new UpdateTankAttr
            {
                tankId = tankId,
                updateType = updateType,
                UpdateVal = updateVal
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
            tankId = reader.ReadUInt32();
            updateType = reader.ReadByte();
            UpdateVal = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(tankId);
            writer.Write(updateType);
            writer.Write(UpdateVal);
        }
    }
}
