using NanoVGDotNet;

namespace Luau.Sim
{
    internal class FeatureRoundedRect : SimFeature
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public float Radius { get; set; }

        public override void Draw(NVGcontext ctx)
        {
            NanoVG.nvgRoundedRect(ctx, X, Y, Width, Height, Radius);
        }
    }
}