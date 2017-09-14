// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.StageMessage
{
    // ----------------------------------------------------------------------
    ///    @file            protocol/StageMessage.h
    ///    @brief
    ///    @author          Bob Lee (bob@sxicube.cn)
    ///    @copyright       Sixcube Information Technology Co,. Ltd. (2012)
    ///    @date            2012/7/12 21:58:15
    // ----------------------------------------------------------------------
    // MSGTYPE_DECLARE_ASSIGN(MSG_NOTIFY_STAGE_REWARD, 1350),
    // 通知阶段性奖励领取信息
    public sealed class NotifyStageReward : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_STAGE_REWARD;
        public short GetMsgType { get { return MsgType; } }
        public uint Stage;// 当前所在的Stage阶段
        public uint Reward;// 有无奖励可领：1-有奖励；0-无奖励
        public uint Reaped;// 领取的时间（未领取为0）
        public uint NextTime;// 倒计时的截至时间
        public uint GetFlag;// 二进制,是否已领取
        
        public static void Send(uint stage, uint reward, uint reaped, uint nextTime, uint getFlag, object className)
        {
            var packet = new NotifyStageReward
            {
                Stage = stage,
                Reward = reward,
                Reaped = reaped,
                NextTime = nextTime,
                GetFlag = getFlag
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
            Stage = reader.ReadUInt32();
            Reward = reader.ReadUInt32();
            Reaped = reader.ReadUInt32();
            NextTime = reader.ReadUInt32();
            GetFlag = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(Stage);
            writer.Write(Reward);
            writer.Write(Reaped);
            writer.Write(NextTime);
            writer.Write(GetFlag);
        }
    }
}