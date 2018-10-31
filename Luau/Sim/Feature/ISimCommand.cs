using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NanoVGDotNet;

namespace Luau.Sim.Feature
{
    public interface ISimCommand
    {
        void Execute(NVGcontext ctx);
    }
}
