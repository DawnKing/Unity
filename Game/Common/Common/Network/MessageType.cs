namespace Common.Network
{
    public static class MessageType
    {
        // EntityMessage
        public const ushort NotifyCreateEntity = 1; // 通知创建实体
        public const ushort RequestEntityMove = 2; // 请求移动
        public const ushort NotifyEntityMove = 3; // 通知移动

        // PlayerMessage
        public const ushort NotifySelfPlayer = 11; // 通知自己

        // SystemMessage
        public const ushort NotifyPing = 21;    // ping

        // AuthMessage
        public const ushort RequestRegister = 101; // 请求验证登陆
        public const ushort RequestAuthLogin = 102; // 请求验证登陆
        public const ushort NotifyLogin = 103;  // 通知登陆

        // BattleMessage
        public const ushort RequestBattle = 201;
    }
}
