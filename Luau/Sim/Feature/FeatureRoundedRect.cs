using NanoVGDotNet;

namespace Luau.Sim.Feature
{
    internal class FeatureRoundedRect : SimFeature
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public float Radius { get; set; }

        public override void Draw(NVGcontext ctx)
        {
            if (Width == 0 || Height == 0)
                return;

            NanoVG.nvgRoundedRect(ctx, X, Y, Width, Height, Radius);
        }
    }
}