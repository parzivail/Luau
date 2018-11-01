using NanoVGDotNet;

namespace Luau.Sim.Feature
{
    internal class CommandPop : SimFeature
    {
        public override void Draw(NVGcontext ctx)
        {
            NanoVG.nvgRestore(ctx);
        }
    }
}