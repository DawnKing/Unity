// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ItemMessage
{
    /// 通知助手操作结果
    public sealed class NotifyBoosterResult : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_BOOSTER_OP_RET;
        public short GetMsgType { get { return MsgType; } }
        public uint type;// 类型 enum ITEM_ACTION_TYPE
        public byte isOk;// 是否成功
        public uint errNo;// 提示id
        public string uuid;// 操作的助手uuid
        public int oldParam;// 操作的就的参数
        public int nowParam;// 操作的新的参数
        
        public static void Send(uint type, byte isOk, uint errNo, string uuid, int oldParam, int nowParam, object className)
        {
            var packet = new NotifyBoosterResult
            {
                type = type,
                isOk = isOk,
                errNo = errNo,
                uuid = uuid,
                oldParam = oldParam,
                nowParam = nowParam
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
            type = reader.ReadUInt32();
            isOk = reader.ReadByte();
            errNo = reader.ReadUInt32();
            uuid = reader.ReadString();
            oldParam = reader.ReadInt32();
            nowParam = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(type);
            writer.Write(isOk);
            writer.Write(errNo);
            writer.Write(uuid);
            writer.Write(oldParam);
            writer.Write(nowParam);
        }
    }
}
