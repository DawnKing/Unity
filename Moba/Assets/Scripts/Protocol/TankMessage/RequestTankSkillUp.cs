// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TankMessage
{
    // 请求坦克技能升级
    public sealed class RequestTankSkillUp : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_TANK_SKILL_UP;
        public short GetMsgType { get { return MsgType; } }
        public string tankUuid;// 坦克的uuid
        public uint Slot;// 强化类型 enum SKILL_SLOT
        
        public static void Send(string tankUuid, uint slot, object className)
        {
            var packet = new RequestTankSkillUp
            {
                tankUuid = tankUuid,
                Slot = slot
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
            tankUuid = reader.ReadString();
            Slot = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(tankUuid);
            writer.Write(Slot);
        }
    }
}