using NanoVGDotNet;

namespace Luau.Sim.Feature
{
    class CommandFillColor : CommandSetColor
    {
        public override void Execute(NVGcontext ctx)
        {
            NanoVG.nvgFillColor(ctx, NanoVG.nvgRGBA(R, G, B, A));
        }
    }
}