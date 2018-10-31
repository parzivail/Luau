using NanoVGDotNet;

namespace Luau.Sim.Feature
{
    class CommandStrokeWidth : ISimCommand
    {
        public float Width { get; set; }

        public void Execute(NVGcontext ctx)
        {
            NanoVG.nvgStrokeWidth(ctx, Width);
        }
    }
}