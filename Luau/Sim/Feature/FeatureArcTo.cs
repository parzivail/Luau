using NanoVGDotNet;

namespace Luau.Sim
{
    internal class FeatureArcTo : SimFeature
    {
        public float Radius { get; set; }
        public float X1 { get; set; }
        public float Y1 { get; set; }

        public override void Draw(NVGcontext ctx)
        {
            NanoVG.nvgArcTo(ctx, X, Y, X1, Y1, Radius);
        }
    }
}