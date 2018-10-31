using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Luau.Sim.Feature;
using NanoVGDotNet;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Luau.Sim
{
    public class Simulator
    {
        private readonly List<ISimCommand> _commandBuffer;
        private readonly List<ISimCommand> _commands;

        public Simulator()
        {
            _commandBuffer = new List<ISimCommand>();
            _commands = new List<ISimCommand>();
        }

        public void Render(NVGcontext nvg)
        {
            NanoVG.nvgStrokeWidth(nvg, 2);
            NanoVG.nvgStrokeColor(nvg, NanoVG.nvgRGBA(0, 0, 0, 255));

            lock (_commands)
            {
                NanoVG.nvgSave(nvg);
                foreach (var simBody in _commands)
                    simBody.Execute(nvg);
                NanoVG.nvgRestore(nvg);
            }
        }

        public void Draw()
        {
            lock (_commands)
            {
                _commands.Clear();
                _commands.AddRange(_commandBuffer);
                _commandBuffer.Clear();
            }
        }

        public void AddCommand(ISimCommand feature)
        {
            _commandBuffer.Add(feature);
        }
    }
}
