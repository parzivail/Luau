using NanoVGDotNet;

namespace Luau.Sim.Feature
{
    internal class FeatureLine : SimFeature
    {
        public float X1 { get; set; }
        public float Y1 { get; set; }

        public override void Draw(NVGcontext ctx)
        {
            if (X == X1 && Y == Y1)
                return;

            NanoVG.nvgBeginPath(ctx);
            NanoVG.nvgMoveTo(ctx, X, Y);
            NanoVG.nvgLineTo(ctx, X1, Y1);
            NanoVG.nvgStroke(ctx);
        }
    }
}