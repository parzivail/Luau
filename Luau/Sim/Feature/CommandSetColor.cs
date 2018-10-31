using NanoVGDotNet;

namespace Luau.Sim.Feature
{
    abstract class CommandSetColor : ISimCommand
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public byte A { get; set; } = 255;

        public abstract void Execute(NVGcontext ctx);
    }
}