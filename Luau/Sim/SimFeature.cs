using NanoVGDotNet;
using OpenTK.Graphics.ES10;

namespace Luau.Sim
{
    public abstract class SimFeature
    {
        public float X { get; set; }
        public float Y { get; set; }

        public abstract void Draw(NVGcontext ctx);
    }
}