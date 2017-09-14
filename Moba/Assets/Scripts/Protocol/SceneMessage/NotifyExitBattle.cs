// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.SceneMessage
{
    // MSGTYPE_DECLARE(MSG_NOTIFY_EXIT_BATTLE),
    /// 通知退出战场
    public sealed class NotifyExitBattle : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_EXIT_BATTLE;
        public short GetMsgType { get { return MsgType; } }
        public uint ErrId;// 错误提示id，参见SystemErr.inl
        public uint SceneId;
        public uint CharId;
        public uint exitType;// enum BATTLE_EXIT_TYPE
        public uint isLook;// 是否观战
        
        public static void Send(uint errId, uint sceneId, uint charId, uint exitType, uint isLook, object className)
        {
            var packet = new NotifyExitBattle
            {
                ErrId = errId,
                SceneId = sceneId,
                CharId = charId,
                exitType = exitType,
                isLook = isLook
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
            ErrId = reader.ReadUInt32();
            SceneId = reader.ReadUInt32();
            CharId = reader.ReadUInt32();
            exitType = reader.ReadUInt32();
            isLook = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(ErrId);
            writer.Write(SceneId);
            writer.Write(CharId);
            writer.Write(exitType);
            writer.Write(isLook);
        }
    }
}
