using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Luau.Lua;
using MoonSharp.Interpreter;

namespace Luau
{
    internal class LuaInterpreter
    {
        public event EventHandler<string> Print;
        public event EventHandler<EventArgs> ExecutionStart;
        public event EventHandler<EventArgs> ExecutionComplete;
        public event EventHandler<InterpreterException> LuaError;
        public event EventHandler<Exception> CsError;

        private readonly Script _script;
        private readonly List<ILuaAddon> _addons = new List<ILuaAddon>
        {
            new LuaFs(),
            new LuaWeb()
        };

        private Thread _luaExecThread;

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

            foreach (var addon in _addons)
                _script.Globals[addon.GetAddonName()] = addon;

            _script.Globals["sleep"] = (Action<int>)Thread.Sleep;
        }

        public void Run(string script)
        {
            _luaExecThread = new Thread(() =>
            {
                try
                {
                    ExecutionStart?.Invoke(this, EventArgs.Empty);
                    _script.DoString(script, codeFriendlyName: "script");
                    ExecutionComplete?.Invoke(this, EventArgs.Empty);
                }
                catch (InterpreterException e)
                {
                    LuaError?.Invoke(this, e);
                }
                catch (Exception e)
                {
                    CsError?.Invoke(this, e);
                }
            });
            _luaExecThread.Start();
        }

        public void Halt()
        {
            _luaExecThread?.Abort();
            ExecutionComplete?.Invoke(this, EventArgs.Empty);
        }
    }
}