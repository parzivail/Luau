using NanoVGDotNet;

namespace Luau.Sim.Feature
{
    internal class FeatureArcTo : SimFeature
    {
        public float Radius { get; set; }
        public float X1 { get; set; }
        public float Y1 { get; set; }

        public override void Draw(NVGcontext ctx)
        {
            if ((X == X1 && Y == Y1) || Radius == 0)
                return;

            NanoVG.nvgArcTo(ctx, X, Y, X1, Y1, Radius);
        }
    }
}