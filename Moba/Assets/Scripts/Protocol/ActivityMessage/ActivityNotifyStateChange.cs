// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ActivityMessage
{
    ///MSGTYPE_DECLARE(MSG_ACTIVITY_NOTIFY_STATE_CHANGE),
    /// 通知客户端，活动的变化信息
    public sealed class ActivityNotifyStateChange : IProtocol
    {
        public const short MsgType = MessageType.MSG_ACTIVITY_NOTIFY_STATE_CHANGE;
        public short GetMsgType { get { return MsgType; } }
        public int activity;
        public int state;/// 0， 准备， 1，开始；2，关闭
        public uint Param;/// 参数
        
        public static void Send(int activity, int state, uint param, object className)
        {
            var packet = new ActivityNotifyStateChange
            {
                activity = activity,
                state = state,
                Param = param
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
            activity = reader.ReadInt32();
            state = reader.ReadInt32();
            Param = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(activity);
            writer.Write(state);
            writer.Write(Param);
        }
    }
}
