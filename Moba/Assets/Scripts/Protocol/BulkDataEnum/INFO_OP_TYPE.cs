// Generated by proto_to_csharp.py. DO NOT EDIT!
namespace GameProtocol.BulkDataEnum
{
    public sealed class INFO_OP_TYPE
    {
        public const int IOT_ADD = 0;//追加（只变更指定的信息）
        public const int IOT_RESET = 1;//重置（需要清空原有信息，然后追加）
        public const int IOT_DELETE = 2;//删除 (删除指定信息)
    }
}
