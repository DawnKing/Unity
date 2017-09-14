using XLua;

public sealed class HotfixManager
{
    public static LuaEnv LuaRuntime = new LuaEnv();

    public static void HotfixConstruction()
    {
        LuaRuntime.DoString(@"
            xlua.private_accessible(CS.EntityAvatar)
            xlua.hotfix(CS.EntityAvatar, '.ctor', 
            function(self)
        	    print('!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!')
            end)
        ");
    }

    public static void HotfixMethod()
    {
        LuaRuntime.DoString(@"
            xlua.private_accessible(CS.BattleModel)
            xlua.hotfix(CS.BattleModel, 'GetPlayerInfo', 
            function(self, id)
        	    print('hotfix')
            end)
        ");
    }
}