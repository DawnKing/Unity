// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.LeagueMessage
{
    //MSGTYPE_DECLARE(MSG_GLOBAL_LEAGUE_PLAYER_LOGIN),
    // 玩家登录
    public sealed class GlobalLeaguePlayerLogin : IProtocol
    {
        public const short MsgType = MessageType.MSG_GLOBAL_LEAGUE_PLAYER_LOGIN;
        public short GetMsgType { get { return MsgType; } }
        public uint TeamId;// 战队id
        public uint CharId;// 进入房间的角色id
        
        public static void Send(uint teamId, uint charId, object className)
        {
            var packet = new GlobalLeaguePlayerLogin
            {
                TeamId = teamId,
                CharId = charId
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
            TeamId = reader.ReadUInt32();
            CharId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(TeamId);
            writer.Write(CharId);
        }
    }
}
