using NanoVGDotNet;

namespace Luau.Sim.Feature
{
    internal class FeatureArc : SimFeature
    {
        public float Radius { get; set; }
        public float A0 { get; set; }
        public float A1 { get; set; }
        public int Dir { get; set; }

        public override void Draw(NVGcontext ctx)
        {
            if (A0 == A1 || Radius == 0)
                return;

            NanoVG.nvgBeginPath(ctx);
            NanoVG.nvgArc(ctx, X, Y, Radius, A0, A1, Dir);
            NanoVG.nvgStroke(ctx);
        }
    }
}