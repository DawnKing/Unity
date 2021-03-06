// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.CharMessage
{
    /// 更新技术信息
    public sealed class UpdateBattleTechno : IProtocol
    {
        public const short MsgType = MessageType.MSG_UPDATE_BATTLE_TECHNO;
        public short GetMsgType { get { return MsgType; } }
        public string szUuid;// 玩家uuid
        public int[] technoVec;// 技术信息 enum GAME_COUNT_TYPE
        public int enemyElo;// 对手的ELO
        public int battleResult;// 战斗结果BATTLE_RESULT
        public int eloUpType;// enum ELO_UPDATE_TYPE
        
        public static void Send(string szUuid, int[] technoVec, int enemyElo, int battleResult, int eloUpType, object className)
        {
            var packet = new UpdateBattleTechno
            {
                szUuid = szUuid,
                technoVec = technoVec,
                enemyElo = enemyElo,
                battleResult = battleResult,
                eloUpType = eloUpType
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
            szUuid = reader.ReadString();
            var length2 = reader.ReadUInt16();
            technoVec = new int[length2];
            for (var i2 = 0; i2 < length2; i2++)
            {
                technoVec[i2] = reader.ReadInt32();
            }
            enemyElo = reader.ReadInt32();
            battleResult = reader.ReadInt32();
            eloUpType = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(szUuid);
            ushort count2 = (ushort)(technoVec == null ? 0 : technoVec.Length);
            writer.Write(count2);
            for(var i2 = 0; i2 < count2; i2++)
            {
                writer.Write(technoVec[i2]);
            }
            writer.Write(enemyElo);
            writer.Write(battleResult);
            writer.Write(eloUpType);
        }
    }
}
