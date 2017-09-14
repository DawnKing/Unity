#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using System;


namespace XLua
{
    public partial class DelegateBridge : DelegateBridgeBase
    {
		
		public BattleEvent __Gen_Delegate_Imp0()
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                
                int __gen_error = LuaAPI.lua_pcall(L, 0, 1, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                BattleEvent __gen_ret = (BattleEvent)translator.GetObject(L, err_func + 1, typeof(BattleEvent));
                LuaAPI.lua_settop(L, err_func - 1);
                return  __gen_ret;
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp1(object self, BattleEventType type, object param)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushAny(L, self);
                translator.Push(L, type);
                translator.PushAny(L, param);
                
                int __gen_error = LuaAPI.lua_pcall(L, 3, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public bool __Gen_Delegate_Imp2(object self, BattleEventType type)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushAny(L, self);
                translator.Push(L, type);
                
                int __gen_error = LuaAPI.lua_pcall(L, 2, 1, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                bool __gen_ret = LuaAPI.lua_toboolean(L, err_func + 1);
                LuaAPI.lua_settop(L, err_func - 1);
                return  __gen_ret;
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public object __Gen_Delegate_Imp3(object self, BattleEventType type)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushAny(L, self);
                translator.Push(L, type);
                
                int __gen_error = LuaAPI.lua_pcall(L, 2, 1, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                object __gen_ret = translator.GetObject(L, err_func + 1, typeof(object));
                LuaAPI.lua_settop(L, err_func - 1);
                return  __gen_ret;
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp4(object self, BattleEventType type)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushAny(L, self);
                translator.Push(L, type);
                
                int __gen_error = LuaAPI.lua_pcall(L, 2, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public GameProtocol.TankMessage.NotifySelfData __Gen_Delegate_Imp5()
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                
                int __gen_error = LuaAPI.lua_pcall(L, 0, 1, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                GameProtocol.TankMessage.NotifySelfData __gen_ret = (GameProtocol.TankMessage.NotifySelfData)translator.GetObject(L, err_func + 1, typeof(GameProtocol.TankMessage.NotifySelfData));
                LuaAPI.lua_settop(L, err_func - 1);
                return  __gen_ret;
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp6(object value)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushAny(L, value);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp7(ulong id)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.lua_pushuint64(L, id);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp8(uint objId)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.xlua_pushuint(L, objId);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public bool __Gen_Delegate_Imp9(ulong id)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.lua_pushuint64(L, id);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 1, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                bool __gen_ret = LuaAPI.lua_toboolean(L, err_func + 1);
                LuaAPI.lua_settop(L, err_func - 1);
                return  __gen_ret;
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public bool __Gen_Delegate_Imp10(uint objId)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.xlua_pushuint(L, objId);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 1, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                bool __gen_ret = LuaAPI.lua_toboolean(L, err_func + 1);
                LuaAPI.lua_settop(L, err_func - 1);
                return  __gen_ret;
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public GameProtocol.TankMessage.TankInfo __Gen_Delegate_Imp11(ulong id)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.lua_pushuint64(L, id);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 1, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                GameProtocol.TankMessage.TankInfo __gen_ret = (GameProtocol.TankMessage.TankInfo)translator.GetObject(L, err_func + 1, typeof(GameProtocol.TankMessage.TankInfo));
                LuaAPI.lua_settop(L, err_func - 1);
                return  __gen_ret;
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public GameProtocol.TankMessage.TankInfo __Gen_Delegate_Imp12(uint objId)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                LuaAPI.xlua_pushuint(L, objId);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 1, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                GameProtocol.TankMessage.TankInfo __gen_ret = (GameProtocol.TankMessage.TankInfo)translator.GetObject(L, err_func + 1, typeof(GameProtocol.TankMessage.TankInfo));
                LuaAPI.lua_settop(L, err_func - 1);
                return  __gen_ret;
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public GameProtocol.TankMessage.TankInfo __Gen_Delegate_Imp13()
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                
                int __gen_error = LuaAPI.lua_pcall(L, 0, 1, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                GameProtocol.TankMessage.TankInfo __gen_ret = (GameProtocol.TankMessage.TankInfo)translator.GetObject(L, err_func + 1, typeof(GameProtocol.TankMessage.TankInfo));
                LuaAPI.lua_settop(L, err_func - 1);
                return  __gen_ret;
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public ulong __Gen_Delegate_Imp14(object self)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushAny(L, self);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 1, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                ulong __gen_ret = LuaAPI.lua_touint64(L, err_func + 1);
                LuaAPI.lua_settop(L, err_func - 1);
                return  __gen_ret;
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp15(object self, ulong value)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushAny(L, self);
                LuaAPI.lua_pushuint64(L, value);
                
                int __gen_error = LuaAPI.lua_pcall(L, 2, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public string __Gen_Delegate_Imp16(object self)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushAny(L, self);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 1, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                string __gen_ret = LuaAPI.lua_tostring(L, err_func + 1);
                LuaAPI.lua_settop(L, err_func - 1);
                return  __gen_ret;
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp17(object self, object value)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushAny(L, self);
                translator.PushAny(L, value);
                
                int __gen_error = LuaAPI.lua_pcall(L, 2, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public UnityEngine.GameObject __Gen_Delegate_Imp18(object self)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushAny(L, self);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 1, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                UnityEngine.GameObject __gen_ret = (UnityEngine.GameObject)translator.GetObject(L, err_func + 1, typeof(UnityEngine.GameObject));
                LuaAPI.lua_settop(L, err_func - 1);
                return  __gen_ret;
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public ZhanChang.UIEntityInfo __Gen_Delegate_Imp19(object self)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushAny(L, self);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 1, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                ZhanChang.UIEntityInfo __gen_ret = (ZhanChang.UIEntityInfo)translator.GetObject(L, err_func + 1, typeof(ZhanChang.UIEntityInfo));
                LuaAPI.lua_settop(L, err_func - 1);
                return  __gen_ret;
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp20(object self, ulong id, object objName)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushAny(L, self);
                LuaAPI.lua_pushuint64(L, id);
                translator.PushAny(L, objName);
                
                int __gen_error = LuaAPI.lua_pcall(L, 3, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public bool __Gen_Delegate_Imp21(object self)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushAny(L, self);
                
                int __gen_error = LuaAPI.lua_pcall(L, 1, 1, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                bool __gen_ret = LuaAPI.lua_toboolean(L, err_func + 1);
                LuaAPI.lua_settop(L, err_func - 1);
                return  __gen_ret;
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp22(object self, float time, UnityEngine.Vector3 position, UnityEngine.Quaternion rotate)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushAny(L, self);
                LuaAPI.lua_pushnumber(L, time);
                translator.PushUnityEngineVector3(L, position);
                translator.PushUnityEngineQuaternion(L, rotate);
                
                int __gen_error = LuaAPI.lua_pcall(L, 4, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp23(object self, UnityEngine.Vector3 position, UnityEngine.Quaternion rotate)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushAny(L, self);
                translator.PushUnityEngineVector3(L, position);
                translator.PushUnityEngineQuaternion(L, rotate);
                
                int __gen_error = LuaAPI.lua_pcall(L, 3, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp24(object self, UnityEngine.Vector3 position)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushAny(L, self);
                translator.PushUnityEngineVector3(L, position);
                
                int __gen_error = LuaAPI.lua_pcall(L, 2, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp25(object self, float time, UnityEngine.Quaternion target)
		{
#if THREAD_SAFT || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.rawL;
                int err_func =LuaAPI.load_error_func(L, errorFuncRef);
                ObjectTranslator translator = luaEnv.translator;
                
                LuaAPI.lua_getref(L, luaReference);
                
                translator.PushAny(L, self);
                LuaAPI.lua_pushnumber(L, time);
                translator.PushUnityEngineQuaternion(L, target);
                
                int __gen_error = LuaAPI.lua_pcall(L, 3, 0, err_func);
                if (__gen_error != 0)
                    luaEnv.ThrowExceptionFromError(err_func - 1);
                
                
                
                LuaAPI.lua_settop(L, err_func - 1);
                
#if THREAD_SAFT || HOTFIX_ENABLE
            }
#endif
		}
        
        
		static DelegateBridge()
		{
		    Gen_Flag = true;
		}
		
		public override Delegate GetDelegateByType(Type type)
		{
		
		    if (type == typeof(__Gen_Hotfix_Delegate0))
			{
			    return new __Gen_Hotfix_Delegate0(__Gen_Delegate_Imp0);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate1))
			{
			    return new __Gen_Hotfix_Delegate1(__Gen_Delegate_Imp1);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate2))
			{
			    return new __Gen_Hotfix_Delegate2(__Gen_Delegate_Imp2);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate3))
			{
			    return new __Gen_Hotfix_Delegate3(__Gen_Delegate_Imp3);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate4))
			{
			    return new __Gen_Hotfix_Delegate4(__Gen_Delegate_Imp4);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate5))
			{
			    return new __Gen_Hotfix_Delegate5(__Gen_Delegate_Imp5);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate6))
			{
			    return new __Gen_Hotfix_Delegate6(__Gen_Delegate_Imp6);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate7))
			{
			    return new __Gen_Hotfix_Delegate7(__Gen_Delegate_Imp7);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate8))
			{
			    return new __Gen_Hotfix_Delegate8(__Gen_Delegate_Imp8);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate9))
			{
			    return new __Gen_Hotfix_Delegate9(__Gen_Delegate_Imp9);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate10))
			{
			    return new __Gen_Hotfix_Delegate10(__Gen_Delegate_Imp10);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate11))
			{
			    return new __Gen_Hotfix_Delegate11(__Gen_Delegate_Imp11);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate12))
			{
			    return new __Gen_Hotfix_Delegate12(__Gen_Delegate_Imp12);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate13))
			{
			    return new __Gen_Hotfix_Delegate13(__Gen_Delegate_Imp13);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate14))
			{
			    return new __Gen_Hotfix_Delegate14(__Gen_Delegate_Imp14);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate15))
			{
			    return new __Gen_Hotfix_Delegate15(__Gen_Delegate_Imp15);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate16))
			{
			    return new __Gen_Hotfix_Delegate16(__Gen_Delegate_Imp16);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate17))
			{
			    return new __Gen_Hotfix_Delegate17(__Gen_Delegate_Imp17);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate18))
			{
			    return new __Gen_Hotfix_Delegate18(__Gen_Delegate_Imp18);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate19))
			{
			    return new __Gen_Hotfix_Delegate19(__Gen_Delegate_Imp19);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate20))
			{
			    return new __Gen_Hotfix_Delegate20(__Gen_Delegate_Imp20);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate21))
			{
			    return new __Gen_Hotfix_Delegate21(__Gen_Delegate_Imp21);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate22))
			{
			    return new __Gen_Hotfix_Delegate22(__Gen_Delegate_Imp22);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate23))
			{
			    return new __Gen_Hotfix_Delegate23(__Gen_Delegate_Imp23);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate24))
			{
			    return new __Gen_Hotfix_Delegate24(__Gen_Delegate_Imp24);
			}
		
		    if (type == typeof(__Gen_Hotfix_Delegate25))
			{
			    return new __Gen_Hotfix_Delegate25(__Gen_Delegate_Imp25);
			}
		
		    throw new InvalidCastException("This delegate must add to CSharpCallLua: " + type);
		}
	}
    
    
    [HotfixDelegate]
    public delegate BattleEvent __Gen_Hotfix_Delegate0();
    
    [HotfixDelegate]
    public delegate void __Gen_Hotfix_Delegate1(object p0, BattleEventType p1, object p2);
    
    [HotfixDelegate]
    public delegate bool __Gen_Hotfix_Delegate2(object p0, BattleEventType p1);
    
    [HotfixDelegate]
    public delegate object __Gen_Hotfix_Delegate3(object p0, BattleEventType p1);
    
    [HotfixDelegate]
    public delegate void __Gen_Hotfix_Delegate4(object p0, BattleEventType p1);
    
    [HotfixDelegate]
    public delegate GameProtocol.TankMessage.NotifySelfData __Gen_Hotfix_Delegate5();
    
    [HotfixDelegate]
    public delegate void __Gen_Hotfix_Delegate6(object p0);
    
    [HotfixDelegate]
    public delegate void __Gen_Hotfix_Delegate7(ulong p0);
    
    [HotfixDelegate]
    public delegate void __Gen_Hotfix_Delegate8(uint p0);
    
    [HotfixDelegate]
    public delegate bool __Gen_Hotfix_Delegate9(ulong p0);
    
    [HotfixDelegate]
    public delegate bool __Gen_Hotfix_Delegate10(uint p0);
    
    [HotfixDelegate]
    public delegate GameProtocol.TankMessage.TankInfo __Gen_Hotfix_Delegate11(ulong p0);
    
    [HotfixDelegate]
    public delegate GameProtocol.TankMessage.TankInfo __Gen_Hotfix_Delegate12(uint p0);
    
    [HotfixDelegate]
    public delegate GameProtocol.TankMessage.TankInfo __Gen_Hotfix_Delegate13();
    
    [HotfixDelegate]
    public delegate ulong __Gen_Hotfix_Delegate14(object p0);
    
    [HotfixDelegate]
    public delegate void __Gen_Hotfix_Delegate15(object p0, ulong p1);
    
    [HotfixDelegate]
    public delegate string __Gen_Hotfix_Delegate16(object p0);
    
    [HotfixDelegate]
    public delegate void __Gen_Hotfix_Delegate17(object p0, object p1);
    
    [HotfixDelegate]
    public delegate UnityEngine.GameObject __Gen_Hotfix_Delegate18(object p0);
    
    [HotfixDelegate]
    public delegate ZhanChang.UIEntityInfo __Gen_Hotfix_Delegate19(object p0);
    
    [HotfixDelegate]
    public delegate void __Gen_Hotfix_Delegate20(object p0, ulong p1, object p2);
    
    [HotfixDelegate]
    public delegate bool __Gen_Hotfix_Delegate21(object p0);
    
    [HotfixDelegate]
    public delegate void __Gen_Hotfix_Delegate22(object p0, float p1, UnityEngine.Vector3 p2, UnityEngine.Quaternion p3);
    
    [HotfixDelegate]
    public delegate void __Gen_Hotfix_Delegate23(object p0, UnityEngine.Vector3 p1, UnityEngine.Quaternion p2);
    
    [HotfixDelegate]
    public delegate void __Gen_Hotfix_Delegate24(object p0, UnityEngine.Vector3 p1);
    
    [HotfixDelegate]
    public delegate void __Gen_Hotfix_Delegate25(object p0, float p1, UnityEngine.Quaternion p2);
    
}