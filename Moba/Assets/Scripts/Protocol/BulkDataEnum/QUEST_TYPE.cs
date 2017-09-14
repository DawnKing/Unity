// Generated by proto_to_csharp.py. DO NOT EDIT!
namespace GameProtocol.BulkDataEnum
{
    public sealed class QUEST_TYPE
    {
        public const int QTT_NONE = 0;
        public const int QTT_DAILY_FIZZ = 1;// 每日活跃度任务
        public const int QTT_ACHIEVEMENT = 2;// 成就任务
        public const int QTT_COMMON = 3;// 主线任务
        public const int QTT_LATERAL = 4;// 分支任务
        public const int QTT_RANK = 5;// 排行任务
        public const int QTT_PROMPT = 6;// 时限任务(欢乐卡、每日)
        public const int QTT_ONLINE = 7;// 保持在线任务（每日）
        public const int QTT_DIRECT = 8;// 指引任务（新手引导，任务面板中不可见）
        public const int QTT_PRESENT = 9;// 馈赠任务 （需要客户端特殊引导，任务面板不可见）
        public const int QTT_STABLE_DAILY = 10;// 日常任务（显示在任务的活动面板）
        public const int QTT_ACT_DAILY = 11;// 活动任务（每日）
        public const int QTT_STABLE_WEEK = 12;/// 周常任务 （显示在任务的活动面板，周一0点重置）
        public const int QTT_TYRO = 13;/// 新手任务
        public const int QTT_ACT_TYRO_TARGET = 14;// 活动时间，新玩家建号成功获得的每日系列任务
        public const int QTT_GUILD_MATCH_RANK = 15;// 军团赛排行
        public const int QTT_ACT_SLICE = 21;// 活动任务(时间片内)
        public const int QTT_ACT_CASH = 22;// 充值、消费任务
        public const int QTT_ACT_AWARD_LIMIT = 23;// 有领取限制的活动任务
        public const int QTT_ACT_CYCLE = 24;// 循环任务
        public const int QTT_FACEBOOK = 31;// facebook任务
        public const int QTT_INVITE = 32;// 邀请好友礼包检查点任务
        public const int QTT_REACTIVE = 33;// 召回老玩家礼包检查点任务
        public const int QTT_RAND_INIT = 34;// 随机初始固定任务
        public const int QTT_RAND_SELECT = 35;// 随机选择任务
        public const int QTT_RAND_SEL_TANK = 36;// 随机选择坦克任务
        public const int QTT_RAND_HAS_TANK = 37;// 随机已有坦克任务
        public const int QTT_RAND_NO_TANK = 38;// 随机未有坦克任务
        public const int QTT_RAND_GUILD = 39;// 随机军团任务
        public const int QTT_RESEARCH = 40;// 日常随机任务
        public const int QTT_ELO_RESET = 41;// 天梯赛季重置任务
        public const int QTT_BE_INVITE = 42;// 受邀请好礼检查点任务
        public const int QTT_BONFIRE = 43;// 篝火活动任务
        public const int QTT_MAX = 44;//
    }
}
