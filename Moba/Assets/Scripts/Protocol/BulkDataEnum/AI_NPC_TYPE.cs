// Generated by proto_to_csharp.py. DO NOT EDIT!
namespace GameProtocol.BulkDataEnum
{
    public sealed class AI_NPC_TYPE
    {
        public const int AINPC_COMMON = 0;// 普通
        public const int AINPC_GLOBAL_BOSS = 1;// 世界boss
        public const int AINPC_MUTABLE_SUMMON = 2;// 能力根据召唤者自适应的召唤物
        public const int AINPC_MUTABLE_MAP = 3;// 根据地图等级自适应的AINPC
        public const int AINPC_SHADOW = 4;// 分身npc
        public const int AINPC_DEAD_ROUND = 5;// 死亡模式回合触发NPC
        public const int AINPC_TANK = 6;// 坦克AINPC（仅对坦克有效的技能，对这类型有效）
        public const int AINPC_GUILD_BOSS = 7;// 军团BOSS
    }
}