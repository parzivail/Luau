using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Luau.Sim;
using Luau.Sim.Feature;
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

        private static void Queue(ISimCommand command)
        {
            LuauForm.Instance.GetSimulator()?.AddCommand(command);
        }

        public void start()
        {
            LuauForm.Instance.ShowSimulator();
        }

        public void draw()
        {
            LuauForm.Instance.GetSimulator()?.Draw();
        }

        public void fillColor(byte r, byte g, byte b)
        {
            Queue(new CommandFillColor { R = r, G = g, B = b });
        }

        public void fillColor(byte r, byte g, byte b, byte a)
        {
            Queue(new CommandFillColor { R = r, G = g, B = b, A = a });
        }

        public void strokeColor(byte r, byte g, byte b)
        {
            Queue(new CommandStrokeColor { R = r, G = g, B = b });
        }

        public void strokeColor(byte r, byte g, byte b, byte a)
        {
            Queue(new CommandStrokeColor { R = r, G = g, B = b, A = a });
        }

        public void strokeWidth(float w)
        {
            Queue(new CommandStrokeWidth { Width = w });
        }

        public void arc(float x, float y, float r, float a0, float a1, int dir)
        {
            Queue(new FeatureArc { X = x, Y = y, Radius = r, A0 = a0, A1 = a1, Dir = dir });
        }

        public void arcTo(float x, float y, float x1, float y1, float r)
        {
            Queue(new FeatureArcTo { X = x, Y = y, X1 = x1, Y1 = y1, Radius = r });
        }

        public void circle(float x, float y, float r)
        {
            Queue(new FeatureCircle { X = x, Y = y, Radius = r });
        }

        public void ellipse(float x, float y, float rX, float rY)
        {
            Queue(new FeatureEllipse { X = x, Y = y, RadiusX = rX, RadiusY = rY});
        }

        public void line(float x, float y, float x1, float y1)
        {
            Queue(new FeatureLine { X = x, Y = y, X1 = x1, Y1 = y1 });
        }

        public void rect(float x, float y, float w, float h)
        {
            Queue(new FeatureRectangle { X = x, Y = y, Width = w, Height = h });
        }

        public void roundedRect(float x, float y, float w, float h, float r)
        {
            Queue(new FeatureRoundedRect { X = x, Y = y, Width = w, Height = h, Radius = r});
        }

        public void moveTo(float x, float y)
        {
            Queue(new CommandMoveTo {X = x, Y = y});
        }

        public void push()
        {
            Queue(new CommandPush());
        }

        public void pop()
        {
            Queue(new CommandPop());
        }
    }
}