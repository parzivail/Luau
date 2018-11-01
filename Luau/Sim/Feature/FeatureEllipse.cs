using NanoVGDotNet;

namespace Luau.Sim.Feature
{
    internal class FeatureEllipse : SimFeature
    {
        public float RadiusX { get; set; }
        public float RadiusY { get; set; }

        public override void Draw(NVGcontext ctx)
        {
            if (RadiusX == 0 || RadiusY == 0)
                return;

            NanoVG.nvgEllipse(ctx, X, Y, RadiusX, RadiusY);
        }
    }
}