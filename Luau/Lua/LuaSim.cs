using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;

namespace Luau.Lua
{
    [MoonSharpUserData]
    internal class LuaSim : ILuaAddon
    {
        public string GetAddonName()
        {
            return "sim";
        }
        
        public void start()
        {
            LuauForm.Instance.ShowSimulator();
        }
    }
}
