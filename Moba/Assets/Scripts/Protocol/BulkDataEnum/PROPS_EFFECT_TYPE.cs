// Generated by proto_to_csharp.py. DO NOT EDIT!
namespace GameProtocol.BulkDataEnum
{
    public sealed class PROPS_EFFECT_TYPE
    {
        public const int PET_NONE = 0;// 没有效果，仅爆炸特效表现
        public const int PET_ADD_HARM = 1;// 炮弹类道具伤害加成
        public const int PET_FIXED_HARM = 2;// 非炮弹类道具造成固定伤害
        public const int PET_LOSSHP_HARM = 3;// 目标失血伤害(对方上限血-对方当前血)
        public const int PET_LESSHP_KILL_HARM = 4;// 剩余血量小于百分比，斩杀
        public const int PET_SELF_LOSSHP_HARM = 5;// 自身失血伤害(自身上限血-自身当前血)
        public const int PET_DISTANCE_HARM = 6;// 根据距离计算伤害
        public const int PET_HARM_MAX = 10;// 伤害效果最大枚举值
        public const int PET_ADD_HP = 11;// 恢复生命
        public const int PET_BUFF = 12;// 产生buff
        public const int PET_CLEAN_BUFF = 13;// 清除buff
        public const int PET_TRANSFER = 14;// 传送
        public const int PET_TANK_LIFE = 15;// 改变坦克命数
        public const int PET_TRANSFER_TO = 16;// 传送到目标
        public const int PET_ADD_SCORE = 17;// 增加分数
        public const int PET_BEAT_BACK = 18;// 击退
        public const int PET_CHANGE_HP = 19;// 交换血量
        public const int PET_THROW = 20;// 投掷
        public const int PET_DEC_SKILL_CD = 21;// 减少目标的技能CD
        public const int PET_COPY_SKILL = 22;// 拷贝技能
        public const int PET_ADD_BUFF_PERSIST = 23;// 增加某BUFF的时间
        public const int PET_ADD_BATTLE_EXP = 25;// 增加战场经验
        public const int PET_RESET_SKILL = 26;// 重置技能
        public const int PET_ADD_MP = 27;// 恢复能量
        public const int PET_DEC_SKILL_CD_TO = 28;// 减少技能CD到某值
        public const int PET_SCENE_BEGIN = 50;// 场景效果起始
        public const int PET_DEL_PROPS = 51;// 清除场景道具
        public const int PET_ADD_PROPS = 52;// 创建场景道具
        public const int PET_CREATE_AI_NPC = 53;// 创建AINpc
        public const int PET_DEL_BULLET = 54;// 清除子弹
        public const int PET_CREATE_BULLET = 55;// 创建子弹
        public const int PET_DEL_SELF_AINPC = 56;// 删除自己的AINpc
        public const int PET_CREATE_NPC = 57;// 创建Npc
        public const int PET_DEL_SELF_NPC = 58;// 删除自己创建的Npc
        public const int PET_SELF_BEGIN = 70;// 攻击方效果起始
        public const int PET_GAIN_BUFF = 71;// 攻击者获得buff(需要上一个效果造成伤害)
        public const int PET_BLOWUP = 73;// 自爆
        public const int PET_SELF_ADD_HP = 74;// 回血
        public const int PET_CALL_BACK = 75;// 收回武器
        public const int PET_SELF_BUFF = 76;// 攻击者获得buff
        public const int PET_DASH = 77;// 冲刺
        public const int PET_COST_UNDEAD_HP = 78;// 攻击扣除不致死的血量N
        public const int PET_ADD_HP_BY_EFFCNT = 79;// 根据目标个数回血
        public const int PET_SELF_DEC_SKILLCD = 80;// 减少自身的技能CD
        public const int PET_HOOK = 81;// 勾爪
        public const int PET_RELIVE = 82;// 重生
        public const int PET_MAX = 83;// 最大值
    }
}
