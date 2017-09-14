// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TankMessage
{
    // 通知研究结果
    public sealed class NotifyResearchTankResult : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_TANK_RESEARCH_RESULT;
        public short GetMsgType { get { return MsgType; } }
        public const int RS_ERROR = 0;/// 研究失败
        public const int RS_ERROR_GOT_TANK = 1;/// 研究失败，已拥有坦克
        public const int RS_ERROR_NO_COIN = 2;/// 研究失败，货币不足
        public const int RS_ERROR_COMPLETED = 3;/// 研究失败，已经研究完成
        public const int RS_ERROR_NOT_OPEN = 4;/// 研究失败，未开放研究
        public const int RS_ERROR_COIN_TYPE_ERROR = 5;/// 研究失败，货币类型错误
        public const int RS_ERROR_DAILY_LIMIT = 6;/// 研究失败，今日研究已达上限
        public const int RS_ERROR_COOL_TIME = 7;/// 研究失败，冷却未结束
        public const int RS_ERROR_LACK_OWN_TANK = 8;/// 研究失败，坦克数量不达标
        public const int RS_OK_NO_BONUS = 10;/// 研究成功
        public const int RS_OK_BONUS_1 = 11;/// 研究成功，有加成
        public const int RS_OK_BONUS_2 = 12;/// 研究成功，有很多加成
        public const int RS_OK_BONUS_3 = 13;/// 研究成功，有超多加成
        public const int RS_OK_USE_CHIP_ITEM = 14;/// 使用研究碎片增加进度
        public uint TankId;///坦克ID
        public uint Result;///研究结果
        public uint Schedule;///当前进度（成功时有效，失败时为0）
        public uint TodayCount;/// 今日已研究次数（成功时有效，失败时为0）
        
        public static void Send(uint tankId, uint result, uint schedule, uint todayCount, object className)
        {
            var packet = new NotifyResearchTankResult
            {
                TankId = tankId,
                Result = result,
                Schedule = schedule,
                TodayCount = todayCount
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
            Result = reader.ReadUInt32();
            Schedule = reader.ReadUInt32();
            TodayCount = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(TankId);
            writer.Write(Result);
            writer.Write(Schedule);
            writer.Write(TodayCount);
        }
    }
}
