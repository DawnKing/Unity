// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

using GameProtocol.BulkDataType;
namespace GameProtocol.TankMessage
{
    // 更新单个坦克的实例信息
    public sealed class UpdateTankInstance : IProtocol
    {
        public const short MsgType = MessageType.MSG_UPDATE_TANK_INSTANCE;
        public short GetMsgType { get { return MsgType; } }
        public TankInstance tankInst;// 坦克的实例信息
        public byte opType;// 类型 enum TANK_INST_OP_TYPE
        
        public static void Send(TankInstance tankInst, byte opType, object className)
        {
            var packet = new UpdateTankInstance
            {
                tankInst = tankInst,
                opType = opType
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
            tankInst = new TankInstance();
            tankInst.ReadFromStream(reader);
            opType = reader.ReadByte();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            tankInst.WriteToStream(writer);
            writer.Write(opType);
        }
    }
}
