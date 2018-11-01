using NanoVGDotNet;

namespace Luau.Sim.Feature
{
    internal class CommandPush : SimFeature
    {
        public override void Draw(NVGcontext ctx)
        {
            NanoVG.nvgSave(ctx);
        }
    }
}