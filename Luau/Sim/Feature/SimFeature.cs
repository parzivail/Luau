using NanoVGDotNet;

namespace Luau.Sim.Feature
{
    public abstract class SimFeature : ISimCommand
    {
        public bool Fill { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

        public abstract void Draw(NVGcontext ctx);

        public void Execute(NVGcontext ctx)
        {
            NanoVG.nvgBeginPath(ctx);
            Draw(ctx);
            if (Fill)
                NanoVG.nvgFill(ctx);
            else
                NanoVG.nvgStroke(ctx);
        }
    }
}