// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TankMessage
{
    // 请求赠送租用坦克
    public sealed class RequestPresentHireTank : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_PRESENT_HIRE_TANK;
        public short GetMsgType { get { return MsgType; } }
        public uint TankId;// 坦克ID
        public uint TankLevel;// 坦克等级
        public uint HireTime;// 租用时间
        public uint CoinVal;// 租用价格
        public string strName;// 目标玩家的名称
        
        public static void Send(uint tankId, uint tankLevel, uint hireTime, uint coinVal, string strName, object className)
        {
            var packet = new RequestPresentHireTank
            {
                TankId = tankId,
                TankLevel = tankLevel,
                HireTime = hireTime,
                CoinVal = coinVal,
                strName = strName
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
            TankId = reader.ReadUInt32();
            TankLevel = reader.ReadUInt32();
            HireTime = reader.ReadUInt32();
            CoinVal = reader.ReadUInt32();
            strName = reader.ReadString();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(TankId);
            writer.Write(TankLevel);
            writer.Write(HireTime);
            writer.Write(CoinVal);
            writer.Write(strName);
        }
    }
}