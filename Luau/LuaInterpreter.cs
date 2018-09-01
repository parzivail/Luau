using System;
using System.Threading;
using Luau.Lua;
using MoonSharp.Interpreter;

namespace Luau
{
    internal class LuaInterpreter
    {
        public event EventHandler<string> Print;
        public event EventHandler<InterpreterException> LuaError;
        public event EventHandler<Exception> CsError;

        private readonly Script _script;

        public LuaInterpreter()
        {
            UserData.RegisterAssembly();

            _script = new Script(CoreModules.Preset_Default)
            {
                Options =
                {
                    DebugPrint = s => Print?.Invoke(this, s)
                }
            };

            _script.Globals["fs"] = new LuaFs();
            _script.Globals["web"] = new LuaWeb();

            _script.Globals["sleep"] = (Action<int>) Thread.Sleep;
        }

        public bool Run(string script)
        {
            try
            {
                _script.DoString(script, codeFriendlyName: "script");
                return true;
            }
            catch (InterpreterException e)
            {
                LuaError?.Invoke(this, e);
            }
            catch (Exception e)
            {
                CsError?.Invoke(this, e);
            }
            return false;
        }
    }
}