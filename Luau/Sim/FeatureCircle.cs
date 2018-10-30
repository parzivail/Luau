using NanoVGDotNet;

namespace Luau.Sim
{
    internal class FeatureCircle : SimFeature
    {
        public float Radius { get; set; }

        public override void Draw(NVGcontext ctx)
        {
            NanoVG.nvgBeginPath(ctx);
            NanoVG.nvgCircle(ctx, X, Y, Radius);
            NanoVG.nvgStroke(ctx);
        }
    }
}