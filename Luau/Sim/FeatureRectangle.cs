using NanoVGDotNet;

namespace Luau.Sim
{
    internal class FeatureRectangle : SimFeature
    {
        public float Width { get; set; }
        public float Height { get; set; }

        public override void Draw(NVGcontext ctx)
        {
            NanoVG.nvgBeginPath(ctx);
            NanoVG.nvgRect(ctx, X, Y, Width, Height);
            NanoVG.nvgStroke(ctx);
        }
    }
}