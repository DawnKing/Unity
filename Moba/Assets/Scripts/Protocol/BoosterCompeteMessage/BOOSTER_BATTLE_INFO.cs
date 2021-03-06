// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.BoosterCompeteMessage
{
    /**
     * 通知助手竞技赛排名变化
     * MSGTYPE_DECLARE(MSG_NOTIFY_BOOSTER_RANK_CHANGE)
    
       message NotifyBstCompRankChange {
     		enum { THIS_MSG_TYPE = MSG_NOTIFY_BOOSTER_RANK_CHANGE; }
     }
      */
    /**
     *助手竞技赛战斗信息
     */
    public sealed class BOOSTER_BATTLE_INFO
    {
        public string strEnemy;/// 对手名称
        public uint BattleResult;/// 战斗结果 enum BOOSTER_BATTLE_RESULT
        public uint Rank;/// 战斗结束后排名
        public uint BattleTime;/// 战斗的日期
        public void ReadFromStream(BinaryReader reader)
        {
            strEnemy = reader.ReadString();
            BattleResult = reader.ReadUInt32();
            Rank = reader.ReadUInt32();
            BattleTime = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(strEnemy);
            writer.Write(BattleResult);
            writer.Write(Rank);
            writer.Write(BattleTime);
        }
    }
}
