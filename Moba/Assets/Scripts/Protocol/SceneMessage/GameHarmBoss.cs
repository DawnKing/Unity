// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.SceneMessage
{
    // MSGTYPE_DECLARE(MSG_GAME_HARM_BOSS),
    // game通知玩家对世界boss造成伤害
    public sealed class GameHarmBoss : IProtocol
    {
        public const short MsgType = MessageType.MSG_GAME_HARM_BOSS;
        public short GetMsgType { get { return MsgType; } }
        public string charUuid;
        public int Harm;
        
        public static void Send(string charUuid, int harm, object className)
        {
            var packet = new GameHarmBoss
            {
                charUuid = charUuid,
                Harm = harm
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
            charUuid = reader.ReadString();
            Harm = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(charUuid);
            writer.Write(Harm);
        }
    }
}
