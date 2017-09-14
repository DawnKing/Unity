// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.SceneMessage
{
    // ----------------------------------------------------------------------
    ///    @file            protocol/RoomMessage.h
    ///    @brief
    ///    @author          linyixiong
    ///    @copyright       Sixcube Information Technology Co,. Ltd. (2012)
    ///    @date
    // ----------------------------------------------------------------------
    // 完胜 对应 完败
    // 胜利 对应 失败
    // 险胜 对应 惜败
    // 敌方投降胜利
    // 平局
    // 战斗时间（分钟）
    // 欢乐赛名次
    // MSGTYPE_DECLARE(MSG_REQUEST_ENTER_BATTLE),
    // 请求进入战场
    public sealed class RequestBattleEnter : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_ENTER_BATTLE;
        public short GetMsgType { get { return MsgType; } }
        public uint SceneId;// 战场id
        
        public static void Send(uint sceneId, object className)
        {
            var packet = new RequestBattleEnter
            {
                SceneId = sceneId
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
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(SceneId);
        }
    }
}
