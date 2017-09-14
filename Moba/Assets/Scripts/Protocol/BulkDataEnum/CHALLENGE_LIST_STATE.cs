// Generated by proto_to_csharp.py. DO NOT EDIT!
namespace GameProtocol.BulkDataEnum
{
    public sealed class CHALLENGE_LIST_STATE
    {
        public const int CLST_NONE = 0;// 无
        public const int CLST_BE_CG_FULL = 1;// 被挑战次数已满
        public const int CLST_CG_GOING = 2;// 正在对战中
        public const int CLST_ARMISTICE = 3;// 休战中
        public const int CLST_CG_DONE = 4;// 已经挑战过
        public const int CLST_NO_ACT = 5;// 不在比赛时间内
        public const int CLST_CG_FULL = 6;// 挑战次数已满
        public const int CLST_PLACE_ERR = 7;// 对方名次不符合
        public const int CLST_SELF = 8;// 自己战队
        public const int CLST_NOSUCHCONTEST = 9;// 对阵不存在
        public const int CLST_CONTESTNOTOPEN = 10;// 对阵状态不是开启状态
        public const int CLST_NOTENROLLED = 11;// 未报名或未进入本轮次
        public const int CLST_NOSUCHGROUP = 12;// 对应的分组不存在
        public const int CLST_NEEDMOREMATES = 13;// 出战人数不足
        public const int CLST_NOTLEADER = 14;// 只有队长才能挑战
        public const int CLST_SELFONFIGHTING = 15;// 本方战队正在战斗中
        public const int CLST_NOTTHETIME = 16;// 不在比赛时间内
        public const int CLST_CONTESTNOTEAM = 17;// 战队不在pContest里
        public const int CLST_CG_DONE_WIN = 18;// 已经挑战过获胜
        public const int CLST_CG_DONE_LOSE = 19;// 已经挑战过失败
        public const int CLST_CG_DONE_ABSENSE = 20;// 双方缺阵
        public const int CLST_CG_BY_SEED = 21;// 种子队不能约战
        public const int CLST_CG_TO_SEED = 22;// 不能约战种子队
        public const int CLST_SQUARE_CLOSED = 23;// 轮次结束
        public const int CLST_TEAM_DISMISSED = 24;// 对方战队已解散
        public const int CLST_DATABASE_ERROR = 25;// 数据错误
        public const int CLST_TEAMDATASYNCING = 26;// 战队数据同步中
    }
}