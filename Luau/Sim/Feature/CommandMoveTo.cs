using NanoVGDotNet;

namespace Luau.Sim
{
    internal class CommandMoveTo : SimFeature
    {
        public override void Draw(NVGcontext ctx)
        {
            NanoVG.nvgMoveTo(ctx, X, Y);
        }
    }
}