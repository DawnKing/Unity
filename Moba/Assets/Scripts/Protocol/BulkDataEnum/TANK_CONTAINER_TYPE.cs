// Generated by proto_to_csharp.py. DO NOT EDIT!
namespace GameProtocol.BulkDataEnum
{
    public sealed class TANK_CONTAINER_TYPE
    {
        public const int TANK_CONT_OWN = 0;// 拥有的
        public const int TANK_CONT_HIRE = 1;// 租用的
        public const int TANK_CONT_FREE_QQ = 2;// Q服的免费的(周免或者试用卡)
        public const int TANK_CONT_FREE_4399 = 3;// 4399的周免（有每日使用限制，有最高等级限制）
        public const int TANK_CONT_TRY_4399 = 4;// 4399的试用
        public const int TANK_CONT_MAX = 5;// 需要保存数据库的枚举最大值
        public const int TANK_CONT_TAG_TRY = 6;// 试用
        public const int TANK_CONT_TAG_NOT_HAVE = 7;// 未拥有 未租用的（客户端专用）
        public const int TANK_CONT_NONE = 100;// 任务用，代表任意容器类型
    }
}
