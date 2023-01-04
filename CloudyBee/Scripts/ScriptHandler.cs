using CloudyBeeEngine.Cache;
using CloudyBeeEngine.Logging;
using CloudyBeeEngine.LUA.Interfaces;
using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;

public static class ScriptHandler
{
    public static Script masterScript;


    static ScriptHandler()
    {
    }

    public static Table ExecuteLuaMethod(Script script, string functionName)//, Dictionary<object, object> globals)
    {

        object luaFunction = script.Globals[functionName];

        if (luaFunction == null)
        {
            //Lua function doesn't exist, log the error and return.
            //Debug.LogError(string.Format(FUNCTION_NOT_FOUND , functionName));
            return null;
        }

        //Call the lua method.
        script.Call(luaFunction);

        return script.Globals;
    }

    public static T ExecuteLuaMethod<T>(string methodName, params string[] parameters)
    {
        return default(T);
    }

    private static void LoadGlobals(Script script, Dictionary<object, object> globals)
    {
        foreach (object key in globals.Keys)
        {
            script.Globals[key] = globals[key];
        }
    }
}