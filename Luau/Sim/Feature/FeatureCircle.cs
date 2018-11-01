using NanoVGDotNet;

namespace Luau.Sim.Feature
{
    internal class FeatureCircle : SimFeature
    {
        public float Radius { get; set; }

        public override void Draw(NVGcontext ctx)
        {
            if (Radius == 0)
                return;

            NanoVG.nvgBeginPath(ctx);
            NanoVG.nvgCircle(ctx, X, Y, Radius);
            NanoVG.nvgStroke(ctx);
        }
    }
}