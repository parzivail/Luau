using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Luau.Sim;
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

        public void draw()
        {
            LuauForm.Instance.GetSimulator()?.Draw();
        }

        public void line(float x, float y, float x1, float y1)
        {
            LuauForm.Instance.GetSimulator()?.AddFeature(new FeatureLine { X = x, Y = y, X1 = x1, Y1 = y1 });
        }

        public void circle(float x, float y, float r)
        {
            var sim = LuauForm.Instance.GetSimulator();
            sim?.AddFeature(new FeatureCircle { X = x, Y = y, Radius = r });
        }

        public void rect(float x, float y, float w, float h)
        {
            LuauForm.Instance.GetSimulator()?.AddFeature(new FeatureRectangle { X = x, Y = y, Width = w, Height = h });
        }
    }
}
