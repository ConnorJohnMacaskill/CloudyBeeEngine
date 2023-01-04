using CloudyBee.Cache;
using CloudyBeeEngine.Attributes;
using CloudyBeeEngine.LUA.Interfaces;
using CloudyBeeEngine.Template.Components;
using MoonSharp.Interpreter;
using System.Collections.Generic;

namespace CloudyBeeEngine.EntitySystem.Components
{
    public class LogicComponent : Component
    {
        //private Dictionary<object, object> customGlobals;
        private Script script;

        public LogicComponent(LogicComponentTemplate logicComponentTemplate) : base()
        {
            Name = logicComponentTemplate.Name;
            Script script;
            ResourcePool.ScriptCache.GetItem(logicComponentTemplate.Script, out script);
            script.Globals["Entity"] = new EntityInterface(GetParentEntityOfComponent(this));
            //customGlobals = new Dictionary<object, object>();

            
        }

        #region Public Properties

        public Script Script { get; set; }

        #endregion Public Properties

        public override void Initialise()
        {
            //customGlobals.Add("", ));
            //customGlobals.Add("", ));

            Table globals = ScriptHandler.ExecuteLuaMethod(Script, "Initialise");//, customGlobals);
            SaveGlobals(globals);

            base.Initialise();
        }

        public override void Update()
        {
            Table globals = ScriptHandler.ExecuteLuaMethod(Script, "Update");
            SaveGlobals(globals);

            NLua.Lua lua = new NLua.Lua();
            DynValue dynValue = new DynValue();
            dynValue.Function.Call();

            base.Update();
        }
    }
}