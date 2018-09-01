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
        public event EventHandler<InterpreterException> LuaError;
        public event EventHandler<Exception> CsError;

        private readonly Script _script;
        private readonly List<ILuaAddon> _addons = new List<ILuaAddon>
        {
            new LuaFs(),
            new LuaWeb()
        };

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

            _script.Globals["sleep"] = (Action<int>)Sleep;
        }

        private static void Sleep(int millis)
        {
            var end = DateTime.Now.AddMilliseconds(millis);
            var i = 0;
            while (DateTime.Now < end)
            {
                if (i++ % 20 == 0)
                    Application.DoEvents();
            }
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