// Generated by proto_to_csharp.py. DO NOT EDIT!
namespace GameProtocol.ClusterDataType
{
    public sealed class AUTH_REG_RESULT
    {
        public const int ARR_UNKNOWN = 0;//位置状态
        public const int ARR_CONFIRM = 1;//注册成功
        public const int ARR_UIDREGGED = 2;//UID已经注册过
        public const int ARR_NOREGION = 3;//REGION不存在
        public const int ARR_NOTINPLAN = 4;//REGION存在，但节点不在REGION计划中
    }
}
