using NanoVGDotNet;

namespace Luau.Sim
{
    internal class FeatureEllipse : SimFeature
    {
        public float RadiusX { get; set; }
        public float RadiusY { get; set; }

        public override void Draw(NVGcontext ctx)
        {
            NanoVG.nvgEllipse(ctx, X, Y, RadiusX, RadiusY);
        }
    }
}