using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NanoVGDotNet;

namespace Luau.Sim.Feature
{
    class CommandStrokeColor : CommandSetColor
    {
        public override void Execute(NVGcontext ctx)
        {
            NanoVG.nvgStrokeColor(ctx, NanoVG.nvgRGBA(R, G, B, A));
        }
    }
}
