using NanoVGDotNet;

namespace Luau.Sim
{
    internal class FeatureLine : SimFeature
    {
        public float X1 { get; set; }
        public float Y1 { get; set; }

        public override void Draw(NVGcontext ctx)
        {
            NanoVG.nvgBeginPath(ctx);
            NanoVG.nvgMoveTo(ctx, X, Y);
            NanoVG.nvgLineTo(ctx, X1, Y1);
            NanoVG.nvgStroke(ctx);
        }
    }
}