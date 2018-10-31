using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using NanoVGDotNet;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Luau.Sim
{
    public class Simulator
    {
        private readonly List<SimFeature> _bodyAccumulator;
        private readonly List<SimFeature> _bodies;

        public Simulator()
        {
            _bodyAccumulator = new List<SimFeature>();
            _bodies = new List<SimFeature>();
        }

        public void Render(NVGcontext nvg)
        {
            NanoVG.nvgStrokeWidth(nvg, 2);
            NanoVG.nvgStrokeColor(nvg, NanoVG.nvgRGBA(0, 0, 0, 255));

            lock (_bodies)
            {
                foreach (var simBody in _bodies)
                {
                    NanoVG.nvgSave(nvg);
                    simBody.Draw(nvg);
                    NanoVG.nvgRestore(nvg);
                }
            }
        }

        public void Draw()
        {
            lock (_bodies)
            {
                _bodies.Clear();
                _bodies.AddRange(_bodyAccumulator);
                _bodyAccumulator.Clear();
            }
        }

        public void AddFeature(SimFeature feature)
        {
            _bodyAccumulator.Add(feature);
        }
    }
}
