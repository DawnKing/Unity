// Generated by proto_to_csharp.py. DO NOT EDIT!
namespace GameProtocol.BulkDataEnum
{
    public sealed class RANGE_TYPE
    {
        public const int RANG_T_CIRCLE = 0;// 圆形范围，范围为0表示单体目标
        public const int RANG_T_LINE = 1;// 线形范围
        public const int RANG_T_SECTOR = 2;// 扇形范围
        public const int RANG_T_DOT = 3;// 点,需要特殊表现
        public const int RANG_T_SELF = 4;// 自身周围
        public const int RANG_T_DESPOS_LINE = 5;// 技能目标点修正的线形范围
        public const int RANG_T_VERTICAL_DIR = 6;// 与技能方向垂直的范围
    }
}
