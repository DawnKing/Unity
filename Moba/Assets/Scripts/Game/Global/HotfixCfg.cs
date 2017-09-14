using System;
using System.Collections.Generic;
using XLua;

public static class HotfixCfg
{
    [Hotfix]
    public static List<Type> by_field = new List<Type>()
    {
        typeof(BattleEvent),
        typeof(BattleModel),
        typeof(EntityAvatar)
    };
}