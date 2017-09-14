// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.SystemMessage
{
    /// GM Command
    public sealed class GmGameCommand : IProtocol
    {
        public const short MsgType = MessageType.MSG_GM_GAME_COMMAND;
        public short GetMsgType { get { return MsgType; } }
        public string command;
        public string gmName;// GM的角色名
        public uint sceneId;// GM所在的场景id
        
        public static void Send(string command, string gmName, uint sceneId, object className)
        {
            var packet = new GmGameCommand
            {
                command = command,
                gmName = gmName,
                sceneId = sceneId
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
            command = reader.ReadString();
            gmName = reader.ReadString();
            sceneId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(command);
            writer.Write(gmName);
            writer.Write(sceneId);
        }
    }
}