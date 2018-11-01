using NanoVGDotNet;

namespace Luau.Sim.Feature
{
    internal class FeatureRectangle : SimFeature
    {
        public float Width { get; set; }
        public float Height { get; set; }

        public override void Draw(NVGcontext ctx)
        {
            if (Width == 0 || Height == 0)
                return;

            NanoVG.nvgBeginPath(ctx);
            NanoVG.nvgRect(ctx, X, Y, Width, Height);
            NanoVG.nvgStroke(ctx);
        }
    }
}